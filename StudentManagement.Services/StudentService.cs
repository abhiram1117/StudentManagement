using SchoolManagement.Data;
using SchoolManagement.Models;
using System.Collections.Generic;



namespace SchoolManagement.Business
{
    public class StudentService
    {
        private string schoolName;
        private List<Student> students = new List<Student>();
        private StudentRepository studentRepository;
        private MarksRepository marksRepository;
        
        public int StudentIdCounter = 1;
        

        public StudentService(string schoolName)
        {
            this.schoolName = schoolName;
            studentRepository = new StudentRepository();
            marksRepository = new MarksRepository();
        }
        public List<Student> GetStudents()
        {
            return studentRepository.GetStudents();
        }

        public void AddStudent(string rollNumberInput, string studentName)
        {
            
            Guid id = GenerateUniqueId();
            Student student = new Student(id, rollNumberInput, studentName);
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

