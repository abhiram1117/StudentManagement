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
        //<<<<<<< Updated upstream:StudentManagement.Services/StudentService.cs
        private int studentIdCounter = 1;
        //=======
        public int StudentIdCounter = 1;
        //>>>>>>> Stashed changes:Bussiness Layer/StudentService.cs

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
            
            int id = GenerateUniqueId();
            Student student = new Student(id, rollNumberInput, studentName);
            //>>>>>>> Stashed changes:Bussiness Layer/StudentService.cs
            studentRepository.AddStudent(student);
        }

        public void AddMarks(string rollNumber, string subject, double marks)
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
        public List<string> GetSubjects()
        {
            return studentRepository.GetSubjects();
        }
        public double GetMarks(Student student, string subject)
        {
            var mark = student.Marks.Find(m => m.Subject == subject);
            if (mark != null)
            {
                return mark.Score;
            }
            else
            {
                return 0.0;
            }
        }
        //<<<<<<< Updated upstream:StudentManagement.Services/StudentService.cs
        public int GenerateUniqueId()
            {
                return StudentIdCounter++;
                //>>>>>>> Stashed changes:Bussiness Layer/StudentService.cs
        }
        }
    }

