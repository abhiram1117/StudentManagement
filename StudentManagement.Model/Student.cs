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
        public Guid SubjectId { get; set; }
        public double Score { get; set; }
        public Mark(Guid subjectid, double score)
        {            
            SubjectId = subjectid;
            Score = score;
        }
    }

    public class Subject
    {
        public Guid SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Subject(Guid subjectid,string name)
        {
            SubjectId = subjectid;
            SubjectName = name;
        }
    }
}