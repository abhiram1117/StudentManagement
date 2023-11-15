using System;
using System.Collections.Generic;

namespace SchoolManagement.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string RollNumber { get; }
        public string Name { get; }
        public List<Mark> Marks { get; set; } = new List<Mark>();

        public Student(int id, string rollNumber, string name)
        {
            Id = id;
            RollNumber = rollNumber;
            Name = name;
        }
        
        
    }
    public class Mark
    {
        public string Subject { get; set; }
        public double Score { get; set; }
    }
}