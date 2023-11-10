using System.Collections.Generic;
using SchoolManagement.Models;

namespace SchoolManagement.Data
{
    public class MarksRepository
    {
        public void AddMarks(Student student, string subject, double marks)
        {
            student.Marks[subject] = marks;
        }

        public double GetMarks(Student student, string subject)
        {
            return student.Marks.ContainsKey(subject) ? student.Marks[subject] : 0.0;
        }
    }
}