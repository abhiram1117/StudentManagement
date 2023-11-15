using SchoolManagement.Models;
using System.Collections.Generic;

namespace SchoolManagement.Data
{
    public static class DataStorage
    {
        public static List<Student> Students { get; } = new List<Student>();
        public static List<Mark> Marks { get; } = new List<Mark>();
        public static List<Subject> subjects { get; } = new List<Subject>
        {
             
            new Subject("Telugu"),
            new Subject("Hindi"),
            new Subject("English"),
            new Subject("Math"),
            new Subject("Science"),
            new Subject("Social")
        
        };
    }
}