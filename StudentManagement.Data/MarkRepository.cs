using System.Collections.Generic;
using SchoolManagement.Models;

namespace SchoolManagement.Data
{
    public class MarksRepository
    {
        public void AddMarks(Student student, string subject, double marks)
        {
            var existingMark = student.Marks.FirstOrDefault(m => m.Subject == subject);

            if (existingMark != null)
            {
                existingMark.Score = marks;
            }
            else
            {
                student.Marks.Add(new Mark { Subject = subject, Score = marks });
            }
        }
    }

        

}
