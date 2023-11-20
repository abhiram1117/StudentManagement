using StudentManagement.Business;
using StudentManagement.Data;
using StudentManagement.Models;
using StudentMangement.Models;

namespace StudentManagement.Program
{
    class Program
    {
        private static StudentService studentService;
        static void Main()
        {
            Console.WriteLine("Enter School name: ");
            string schoolName = Console.ReadLine();
            studentService = new StudentService(schoolName);
            Console.WriteLine();
            Console.WriteLine($"Welcome to {schoolName} Student information management");
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("Menu Options:");
                Console.WriteLine("1. Add student");
                Console.WriteLine("2. Add marks for student");
                Console.WriteLine("3. Show student progress card");
                Console.WriteLine("4. Exit");
                Console.WriteLine();
                Console.WriteLine("Please select a menu option: ");
                if (Enum.TryParse<MenuOption>(Console.ReadLine(), out MenuOption choice))
                {
                    switch (choice)
                    {
                        case MenuOption.AddStudent:
                            AddStudent();
                            break;
                        case MenuOption.AddMarks:
                            AddMarks();
                            break;
                        case MenuOption.ShowProgressCard:
                            ShowProgressCard();
                            break;
                        case MenuOption.Exit:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid menu option. Please select a valid option.");
                }
            }
        }

        private static void AddStudent()
        {
            try
            {
                Console.WriteLine("Enter Student Roll Number: ");
                string rollNumber = Console.ReadLine();
                if (DataStorage.Students.Exists(student => string.Equals(student.RollNumber, rollNumber)))
                {
                    throw new StudentAlreadyExistsException();
                }

                Console.WriteLine("Enter Student Name: ");
                string studentName = Console.ReadLine();
                studentService.AddStudent(rollNumber, studentName);
                Console.WriteLine("Student details are added successfully");

            }
            catch (StudentAlreadyExistsException ex)
            { 
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
        }


        private static void AddMarks()
        {
            Console.WriteLine("Enter Student Roll Number: ");
            string rollNumber = Console.ReadLine();
            Student student = studentService.GetStudentByRollNumber(rollNumber);
            if (student != null)
            {
                foreach (Subject subject in studentService.GetSubjects())
                {
                    double marks;
                    do
                    {
                        Console.Write($"Enter Marks scored in {subject.SubjectName} : ");
                        if (double.TryParse(Console.ReadLine(), out marks))
                        {
                            if (marks < 0 || marks > 100)
                            {
                                Console.WriteLine("Invalid input for marks. Please enter a valid number between 0 and 100.");
                            }
                            else
                            {
                                studentService.AddMarks(rollNumber, subject, marks);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for marks. Please enter a valid number.");
                        }
                    } while (marks < 0 || marks > 100);
                }
                Console.WriteLine("Student marks are added successfully");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Student with the provided roll number not found.");
                Console.WriteLine();
            }
        }

        private static void ShowProgressCard()
        {
            Console.WriteLine("Enter Student Roll Number: ");
            string progressCardRollNumber = Console.ReadLine();
            Student progressCardStudent = studentService.GetStudentByRollNumber(progressCardRollNumber);
            if (progressCardStudent != null)
            {
                Console.WriteLine($"Student Roll Number: {progressCardRollNumber}");
                Console.WriteLine($"Student Name: {progressCardStudent.Name}");
                Console.WriteLine("Student Marks");
                Console.WriteLine("----------------------------------------------");
                foreach (Subject subject in studentService.GetSubjects())
                {
                    
                    Console.WriteLine($"{subject.SubjectName} : {studentService.GetMarks(progressCardStudent, subject)}");
                }
                Console.WriteLine("----------------------------------------------");

                double totalMarks = studentService.CalculateTotalMarks(progressCardStudent);
                double percentage = studentService.CalculatePercentage(progressCardStudent);

                Console.WriteLine($"Total Marks: {totalMarks}");
                Console.WriteLine($"Percentage: {percentage}%");
            }
            else
            {
                Console.WriteLine("Student with the provided roll number not found.");
            }
            Console.WriteLine();
        }
    }
}
