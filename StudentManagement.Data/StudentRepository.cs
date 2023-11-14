using System.Collections.Generic;
using System.Linq;
using SchoolManagement.Models;

namespace SchoolManagement.Data
{
    public class StudentRepository
    {
        private List<Student> students = new List<Student>();

        private List<string> subjects = new List<string> { "Telugu", "Hindi", "English", "Math", "Science", "Social" };

        public List<Student> GetStudents()
        {
            return students;
        }

        public Student GetStudentByRollNumber(string rollNumber)
        {
            return students.FirstOrDefault(students => students.RollNumber == rollNumber);
        }
        public void AddStudent(Student student)
        {
            students.Add(student);
        }
        public List<string> GetSubjects()
        {
            return subjects;
        }
    }
}