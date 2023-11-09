using System;
using System.Collections.Generic;

namespace SchoolManagement.Models
{
    public class Student
    {
        public string RollNumber { get; }
        public string Name { get; }
        public Dictionary<string, double> Marks { get; } = new Dictionary<string, double>();

        public Student(string rollNumber, string name)
        {
            RollNumber = rollNumber;
            Name = name;
        }
    }
}