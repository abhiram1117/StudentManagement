using System.Collections.Generic;
using SchoolManagement.Models;

namespace SchoolManagement.Data
{
    public class MarksRepository
    {
        public void AddMarks(Student student, Subject subject, double marks)
        {
            var existingMark = student.Marks.FirstOrDefault(m => m.Subject.Equals(subject.SubjectName, StringComparison.OrdinalIgnoreCase));

            if (existingMark != null)
            {
                existingMark.Score = marks;
            }
            else
            {
                student.Marks.Add(new Mark { Subject = subject.SubjectName, Score = marks });
            }
        }
        public double GetMarks(Student student, Subject subject)
        {

            var mark = student.Marks.Find(m => m.Subject.Equals(subject.SubjectName, StringComparison.OrdinalIgnoreCase));
            if (mark != null)
            {
                return mark.Score;
            }
            else
            {
                return 0.0;
            }
        }
    }

        

}
