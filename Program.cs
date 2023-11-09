using System;
using SchoolManagement.Business;
using SchoolManagement.Data;
using SchoolManagement.Models;


namespace SchoolManagement.Program
{
    class Program
    {
        enum MenuOption
        {
            AddStudent = 1,
            AddMarks,
            ShowProgressCard,
            Exit
        }

        static void Main()
        {
            Console.WriteLine("Enter School name: ");
            string schoolName = Console.ReadLine();
            Console.WriteLine();

            var studentManagement = new StudentManagement(schoolName);
            var addedRollNumbers = new List<string>();

            Console.WriteLine("Welcome to " + schoolName + " Student information management");
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
                            Console.WriteLine("Enter Student Roll Number: ");
                            string rollNumberInput = Console.ReadLine();
                            if (addedRollNumbers.Contains(rollNumberInput))
                            {
                                Console.WriteLine("Student with the provided roll number already exists.");
                            }
                            else
                            {
                                Console.WriteLine("Enter Student Name: ");
                                string studentName = Console.ReadLine();
                                studentManagement.AddStudent(rollNumberInput, studentName);
                                addedRollNumbers.Add(rollNumberInput);
                                Console.WriteLine("Student details are added successfully");
                            }
                            Console.WriteLine();
                            break;

                        case MenuOption.AddMarks:
                            Console.WriteLine("Enter Student Roll Number: ");
                            string rollNumber = Console.ReadLine();
                            var student = studentManagement.GetStudentByRollNumber(rollNumber);

                            if (student != null)
                            {
                                foreach (var subject in studentManagement.GetSubjects())
                                {
                                    double marks;
                                    do
                                    {
                                        Console.Write("Enter Marks scored in " + subject + ": ");
                                        if (double.TryParse(Console.ReadLine(), out marks))
                                        {
                                            if (marks < 0 || marks > 100)
                                            {
                                                Console.WriteLine("Invalid input for marks. Please enter a valid number between 0 and 100.");
                                            }
                                            else
                                            {
                                                studentManagement.AddMarks(rollNumber, subject, marks);
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
                            break;

                        case MenuOption.ShowProgressCard:
                            Console.WriteLine("Enter Student Roll Number: ");
                            string progressCardRollNumber = Console.ReadLine();
                            var progressCardStudent = studentManagement.GetStudentByRollNumber(progressCardRollNumber);
                            if (progressCardStudent != null)
                            {
                                Console.WriteLine("Student Roll Number: " + progressCardRollNumber);
                                Console.WriteLine("Student Name: " + progressCardStudent.Name);
                                Console.WriteLine("Student Marks");
                                Console.WriteLine("----------------------------------------------");
                                foreach (var subject in studentManagement.GetSubjects())
                                {
                                    Console.WriteLine(subject + ": " + studentManagement.GetMarks(progressCardStudent, subject));
                                }
                                Console.WriteLine("----------------------------------------------");

                                double totalMarks = studentManagement.CalculateTotalMarks(progressCardStudent);
                                double percentage = studentManagement.CalculatePercentage(progressCardStudent);

                                Console.WriteLine("Total Marks: " + totalMarks);
                                Console.WriteLine("Percentage: " + percentage + "%");
                            }
                            else
                            {
                                Console.WriteLine("Student with the provided roll number not found.");
                            }
                            Console.WriteLine();
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
    }
}