using SchoolManagement.Data;
using SchoolManagement.Models;

namespace SchoolManagement.Business
{
    public class StudentService
    {
        private string schoolName;
        private StudentRepository studentRepository;
        private MarksRepository marksRepository;                

        public StudentService(string schoolName)
        {
            this.schoolName = schoolName;
            studentRepository = new StudentRepository();
            marksRepository = new MarksRepository();
        }        

        public void AddStudent(string rollNumber, string studentName)
        {
            
            Guid id = GenerateUniqueId();
            Student student = new Student(id, rollNumber, studentName);
            studentRepository.AddStudent(student);
        }

        public void AddMarks(string rollNumber, Subject subject, double marks)
        {

            Student student = studentRepository.GetStudentByRollNumber(rollNumber);
            if (student != null)
            {
                marksRepository.AddMarks(student, subject, marks);
            }
        }

        public Student GetStudentByRollNumber(string rollNumber)
        {
            return studentRepository.GetStudentByRollNumber(rollNumber);
        }

        public double CalculateTotalMarks(Student student)
        {
            double total = 0.0;
            foreach (var mark in student.Marks)
            {
                total += mark.Score;
            }
            return total;
        }

        public double CalculatePercentage(Student student)
        {
            double totalMarks = CalculateTotalMarks(student);
            return (totalMarks / (studentRepository.GetSubjects().Count * 100)) * 100;
        }
        public List<Subject> GetSubjects()
        {
            return studentRepository.GetSubjects();
        }
        public double GetMarks(Student student, Subject subject)
        {
            return marksRepository.GetMarks(student, subject);
        }

        public Guid GenerateUniqueId()
        {
            return Guid.NewGuid();
        }
    }
    }