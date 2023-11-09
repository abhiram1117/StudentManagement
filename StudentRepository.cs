using SchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            return students.FirstOrDefault(s => s.RollNumber == rollNumber);
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void AddMarks(Student student, string subject, double marks)
        {
            student.Marks[subject] = marks;
        }

        public double GetMarks(Student student, string subject)
        {
            return student.Marks.ContainsKey(subject) ? student.Marks[subject] : 0.0;
        }

        public List<string> GetSubjects()
        {
            return subjects;
        }
    }
}
