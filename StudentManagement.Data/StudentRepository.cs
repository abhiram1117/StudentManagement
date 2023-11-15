using System.Collections.Generic;
using System.Linq;
using SchoolManagement.Models;


namespace SchoolManagement.Data
{
    public class StudentRepository
    {
        public static class DataStorage
        {
            public static List<Student> students { get; } = new List<Student>();
            public static List<Mark> Marks { get; } = new List<Mark>();
            public static List<Subject> subjects = new List<Subject>();
             

        }
        public List<Student> GetStudents()
        {
            return DataStorage.students;
        }

        public Student GetStudentByRollNumber(string rollNumber)
        {
            return DataStorage.students.FirstOrDefault(s => string.Equals(s.RollNumber, rollNumber, StringComparison.OrdinalIgnoreCase));
        }
        public void AddStudent(Student student)
        {
            DataStorage.students.Add(student);
        }
        public List<Subject> GetSubjects()
        {
            return DataStorage.subjects.ToList();
        }
    }
}