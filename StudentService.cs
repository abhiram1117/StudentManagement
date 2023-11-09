using SchoolManagement.Data;
using SchoolManagement.Models;


namespace SchoolManagement.Business
{
    public class StudentManagement
    {
        private string schoolName;
        private StudentRepository studentRepository;

        public StudentManagement(string schoolName)
        {
            this.schoolName = schoolName;
            studentRepository = new StudentRepository();
        }

        public void AddStudent(string rollNumberInput, string studentName)
        {
            var student = new Student(rollNumberInput, studentName);
            studentRepository.AddStudent(student);
        }

        public void AddMarks(string rollNumber, string subject, double marks)
        {
            var student = studentRepository.GetStudentByRollNumber(rollNumber);
            if (student != null)
            {
                studentRepository.AddMarks(student, subject, marks);
            }
        }

        public Student GetStudentByRollNumber(string rollNumber)
        {
            return studentRepository.GetStudentByRollNumber(rollNumber);
        }

        public double CalculateTotalMarks(Student student)
        {
            double total = 0.0;
            foreach (var subject in studentRepository.GetSubjects())
            {
                total += studentRepository.GetMarks(student, subject);
            }
            return total;
        }


        public double CalculatePercentage(Student student)
        {
            double totalMarks = CalculateTotalMarks(student);
            return (totalMarks / (studentRepository.GetSubjects().Count * 100))*100;
        }
        public List<string> GetSubjects()
        {
            return studentRepository.GetSubjects();
        }
        public double GetMarks(Student student ,  string subject)
        {
            return studentRepository.GetMarks(student, subject);
        }
    }
}
