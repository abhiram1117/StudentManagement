﻿using StudentManagement.Models;

namespace StudentManagement.Data
{
    public class StudentRepository
    {
        public Student GetStudentByRollNumber(string rollNumber)
        {
            return DataStorage.Students.FirstOrDefault(s => string.Equals(s.RollNumber, rollNumber, StringComparison.OrdinalIgnoreCase));
        }
        public void AddStudent(Student student)
        {
            DataStorage.Students.Add(student);
        }
        public List<Subject> GetSubjects()
        {
            return DataStorage.Subjects.ToList();
        }
    }
}