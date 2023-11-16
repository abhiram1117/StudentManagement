using System;
using System.Collections.Generic;

namespace SchoolManagement.Models
{
    public class Student
    {
        public Guid Id { get;  set; }
        public string RollNumber { get; }
        public string Name { get; }
        public List<Mark> Marks { get; set; } = new List<Mark>();
        public Student(Guid id, string rollNumber, string name)
        {
            Id = id;
            RollNumber = rollNumber;
            Name = name;
        }                
    }

    public class Mark
    {
        public Guid MarksId { get; set; }
        public string Subject { get; set; }
        public double Score { get; set; }
        public Mark(string subject, double score)
        {            
            Subject = subject;
            Score = score;
        }
    }

    public class Subject
    {
        public Guid SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Subject(string name)
        {       
            SubjectName = name;
        }
    }
}