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
            public static List<string> subjects { get; } = new List<string> { "Telugu", "Hindi", "English", "Math", "Science", "Social" };

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
        public List<string> GetSubjects()
        {
            return DataStorage.subjects;
        }
    }
}