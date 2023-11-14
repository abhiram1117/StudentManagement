using System;
using System.Collections.Generic;

namespace SchoolManagement.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string RollNumber { get; }
        public string Name { get; }
        public Dictionary<string, double> Marks { get; } = new Dictionary<string, double>();

        public Student(int id, string rollNumber, string name)
        {
            Id = id;
            RollNumber = rollNumber;
            Name = name;
        }
    }
}