using StudentManagement.Models;

namespace StudentManagement.Data
{
    public class MarksRepository
    {
        public void AddMarks(Student student, Subject subject, double marks)
        {
            Mark existingmark = student.Marks.FirstOrDefault(m =>m.SubjectId.Equals(subject.SubjectId));
            if (existingmark != null)
            {
                existingmark.Score = marks;

            }
            else
            {
                student.Marks.Add(new Mark(subject.SubjectId, marks));
            }
        }        
    

        public double GetMarks(Student student, Subject subject)
        {
        Mark existingmark = student.Marks.Find(m => m.SubjectId.Equals(subject.SubjectId));
        if (existingmark != null)
        {
            return existingmark.Score;

        }
        else
        {
            return 0;
        }
        }
    }

        

}
