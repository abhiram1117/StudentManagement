using System;
using System.ComponentModel.Design;

class Program
{
    static List<Student> students = new List<Student>();
    static void Main()
    {
        Console.WriteLine("Enter School name: ");
        string schoolName = Console.ReadLine();  
        Console.WriteLine(" ");
        
            while (true)
            {
                Console.WriteLine("-------------------------------------------------------------------------------------------");
                Console.WriteLine("-------------------------------------------------------------------------------------------");
                Console.WriteLine(" ");
                Console.WriteLine("Welcome to " + schoolName + " Student information management");
                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine(" ");
                Console.WriteLine("1. Add student");
                Console.WriteLine("2. Add marks for student");
                Console.WriteLine("3. Show student progress card");
                Console.WriteLine(" ");
                Console.WriteLine("Please provide valid input from menu options : ");
                string menuInput = Console.ReadLine();
                Console.WriteLine(" ");



                if (int.TryParse(menuInput, out int choice))
                {

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter Student Roll Number : ");
                            string rollNumberInput = Console.ReadLine();
                            Console.WriteLine("Enter Student Name : ");
                            string studentName = Console.ReadLine();
                            Console.WriteLine("Student details are added successfully");
                            students.Add(new Student(rollNumberInput, studentName));
                            Console.WriteLine(" ");
                            Console.WriteLine("Press any key to continue");
                            break;
                        case 2:
                            Console.WriteLine("Enter Student Roll Number : ");
                            string addMarksRollNumber = Console.ReadLine();
                            Student student = students.Find(s => s.RollNumber == addMarksRollNumber);
                            if (student != null)
                            {
                                foreach (var subject in student.Subjects)
                                {
                                    Console.Write("Enter Marks scored in " + subject + " : ");
                                    double marks = double.Parse(Console.ReadLine());
                                    student.AddMarks(subject, marks);
                                }
                                Console.WriteLine("Student marks are added successfully");
                            }
                            else
                            {
                                Console.WriteLine("Student with the provided roll number not found.");
                            }
                            Console.WriteLine(" ");
                            Console.WriteLine("Press any key to continue");
                            break;
                        case 3:
                            Console.WriteLine("Enter Student Roll Number : ");
                            string progressCardRollNumber = Console.ReadLine();
                            Student progressCardStudent = students.Find(s => s.RollNumber == progressCardRollNumber);
                            if (progressCardStudent != null)
                            {
                                Console.WriteLine("Student Roll Number : " + progressCardRollNumber);
                                Console.WriteLine("Student Name : " + progressCardStudent.Name);
                                Console.WriteLine("Student Marks");
                                Console.WriteLine("----------------------------------------------");
                                foreach (var subject in progressCardStudent.Subjects)
                                {
                                    Console.WriteLine(subject + ": " + progressCardStudent.GetMarks(subject));
                                }
                                Console.WriteLine("----------------------------------------------");
                                Console.WriteLine(" ");
                                double totalMarks = progressCardStudent.CalculateTotalMarks();
                                double percentage = progressCardStudent.CalculatePercentage();
                                Console.WriteLine("Total Marks: " + totalMarks);
                                Console.WriteLine("Percentage: " + percentage);
                            }
                            else
                            {
                                Console.WriteLine("Student with the provided roll number not found.");
                            }
                            Console.WriteLine(" ");
                            Console.WriteLine("Press any key to continue");
                            Console.WriteLine(" ");


                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
            
            }
            
         
          
        
    }
}
class Student
{
    public string RollNumber { get; }
    public string Name { get; }
    public Dictionary<string, double> Marks { get; } = new Dictionary<string, double>();
    public List<string> Subjects { get; } = new List<string> { "Telugu", "Hindi", "English", "Math", "Science", "Social" };

    public Student(string rollNumber, string name)
    {
        RollNumber = rollNumber;
        Name = name;
    }
    public void AddMarks(string subject, double marks)
    {
        Marks[subject] = marks;
    }
    public double GetMarks(string subject)
    {
        return Marks.ContainsKey(subject) ? Marks[subject] : 0.0;
    }
    public double CalculateTotalMarks()
    {
        double total = 0.0;
        foreach (var subject in Subjects)
        {
            total += GetMarks(subject);
        }
        return total;
    }

    public double CalculatePercentage()
    {
        double totalMarks = CalculateTotalMarks();
        return (totalMarks / (Subjects.Count * 100)) * 100;
    }
}