using SchoolManagement.Models;

namespace SchoolManagement.Data
{
    public static class DataStorage
    {
        public static List<Student> Students { get; } = new List<Student>();
        public static List<Mark> Marks { get; } = new List<Mark>();
        public static List<Subject> Subjects { get; } = new List<Subject>
        {            
            new Subject(Guid.NewGuid(),"Telugu"),
            new Subject(Guid.NewGuid(), "Hindi"),
            new Subject(Guid.NewGuid(), "English"),
            new Subject(Guid.NewGuid(), "Math"),
            new Subject(Guid.NewGuid(), "Science"),
            new Subject(Guid.NewGuid(), "Social")      
        };
    }
}