using System;
using Student_Domain;
using Student_Repository;

namespace Student_ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool isRun = true;
            while (isRun)
            {
                Console.Clear();
                Console.WriteLine("=============== STUDENT MANAGEMENT SYSTEM ===============");
                Console.WriteLine("1. Students (Factory Pattern)");
                Console.WriteLine("2. Manage Student Types (Factory Method Pattern)");
                Console.WriteLine("3. Exit");
                Console.Write("\nSelect Option: ");

                string inputKey = Console.ReadLine();
                Console.Clear();

                switch (inputKey)
                {
                    case "1":
                        ManageStudents();
                        break;
                    case "2":
                        ManageStudentTypes();
                        break;
                    case "3":
                        isRun = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option! Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ManageStudents()
        {
            bool studentRun = true;
            var repo = RepositoryFactory.Create<IStudentRepository>(ContextTypes.XMLSource);

            while (studentRun)
            {
                Console.Clear();
                Console.WriteLine("========== Students (Factory Pattern) ==========");
                Console.WriteLine("1. View All Students");
                Console.WriteLine("2. Add Student");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("B. Back");
                Console.Write("\nSelect Option: ");

                string choice = Console.ReadLine()?.ToUpper();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        ViewStudents(repo);
                        break;
                    case "2":
                        AddStudent(repo);
                        break;
                    case "3":
                        UpdateStudent(repo);
                        break;
                    case "4":
                        DeleteStudent(repo);
                        break;
                    case "B":
                        studentRun = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option! Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }

            Console.WriteLine("\nReturning to Main Menu...");
            Console.ReadKey();
        }

        static void ViewStudents(IStudentRepository repo)
        {
            var students = repo.GetAll();
            Console.WriteLine("=========== Student List ===========");
            foreach (var s in students)
            {
                Console.WriteLine($"{s.ID} | {s.Name}, Age: {s.Age}, Class: {s.Class}");
            }
            Console.WriteLine("\nPress any key to go back...");
            Console.ReadKey();
        }

        static void AddStudent(IStudentRepository repo)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========== Add Student ==========");
                Console.WriteLine("B. Back to Student Menu");

                Console.Write("Name: ");
                string name = Console.ReadLine();
                if (name.ToUpper() == "B") break;

                Console.Write("Age: ");
                string ageInput = Console.ReadLine();
                if (ageInput.ToUpper() == "B") break;

                Console.Write("Class: ");
                string cls = Console.ReadLine();
                if (cls.ToUpper() == "B") break;

                Student s = new Student
                {
                    Name = name,
                    Age = int.Parse(ageInput),
                    Class = cls
                };

                repo.Insert(s);
                Console.WriteLine("\nStudent Added Successfully! (Factory Pattern)");

                Console.WriteLine("\nPress any key to continue adding or B to back...");
                string backCheck = Console.ReadLine();
                if (backCheck.ToUpper() == "B") break;
            }
        }

        static void UpdateStudent(IStudentRepository repo)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========== Update Student ==========");
                Console.WriteLine("B. Back to Student Menu");

                Console.Write("Enter Student ID to Update: ");
                string input = Console.ReadLine();
                if (input.ToUpper() == "B") break;

                if (int.TryParse(input, out int id))
                {
                    var student = repo.Get(id);
                    if (student != null)
                    {
                        Console.Write($"Name ({student.Name}): ");
                        string name = Console.ReadLine();
                        if (!string.IsNullOrEmpty(name)) student.Name = name;

                        Console.Write($"Age ({student.Age}): ");
                        string age = Console.ReadLine();
                        if (!string.IsNullOrEmpty(age)) student.Age = int.Parse(age);

                        Console.Write($"Class ({student.Class}): ");
                        string cls = Console.ReadLine();
                        if (!string.IsNullOrEmpty(cls)) student.Class = cls;

                        if (repo.Update(student))
                            Console.WriteLine("\nStudent Updated Successfully!");
                        else
                            Console.WriteLine("\nUpdate Failed!");
                    }
                    else
                    {
                        Console.WriteLine("Student not found!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid ID!");
                }

                Console.WriteLine("\nPress any key to continue or B to back...");
                string backCheck = Console.ReadLine();
                if (backCheck.ToUpper() == "B") break;
            }
        }

        static void DeleteStudent(IStudentRepository repo)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========== Delete Student ==========");
                Console.WriteLine("B. Back to Student Menu");

                Console.Write("Enter Student ID to Delete: ");
                string input = Console.ReadLine();
                if (input.ToUpper() == "B") break;

                if (int.TryParse(input, out int id))
                {
                    if (repo.Delete(id))
                        Console.WriteLine("Student Deleted Successfully!");
                    else
                        Console.WriteLine("Student not found or delete failed!");
                }
                else
                {
                    Console.WriteLine("Invalid ID!");
                }

                Console.WriteLine("\nPress any key to continue or B to back...");
                string backCheck = Console.ReadLine();
                if (backCheck.ToUpper() == "B") break;
            }
        }

        static void ManageStudentTypes()
        {
            bool typeRun = true;
            while (typeRun)
            {
                Console.Clear();
                Console.WriteLine("=========== Student Types (Factory Method Pattern) ===========");
                Console.WriteLine("1. Graduate Student");
                Console.WriteLine("2. Undergraduate Student");
                Console.WriteLine("B. Back");
                Console.Write("\nEnter choice: ");

                string choice = Console.ReadLine()?.ToUpper();
                StudentTypeCreator creator = null;

                switch (choice)
                {
                    case "1":
                        creator = new GraduateCreator();
                        break;
                    case "2":
                        creator = new UndergraduateCreator();
                        break;
                    case "B":
                        typeRun = false;
                        continue;
                    default:
                        creator = null;
                        break;
                }

                if (creator != null)
                {
                    var type = creator.CreateStudentType();
                    type.Display();
                    Console.WriteLine("\nPress any key to go back...");
                    Console.ReadKey();
                }
                else if (choice != "B")
                {
                    Console.WriteLine("Invalid option!");
                    Console.ReadKey();
                }
            }

            Console.WriteLine("\nReturning to Main Menu...");
            Console.ReadKey();
        }
    }
}
