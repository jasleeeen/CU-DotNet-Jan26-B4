using LayeredStudMgmtSystem.Models;
using LayeredStudMgmtSystem.Repositories;
using LayeredStudMgmtSystem.Services;
using Microsoft.VisualBasic.FileIO;

namespace LayeredStudMgmtSystem.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Student Management System");
            Console.WriteLine("List or JSON (1/2) ?");
            var options = int.Parse(Console.ReadLine());
            IStudentRepository repo = null;
            if (options == 1)
            {
                repo = new ListStudentRepository();
                Console.WriteLine("Using in-memory storage/List\n");
            }
            else if (options == 2)
            {
                repo = new JsonStudentRepository();
                Console.WriteLine("Using JSON\n");
            }
            else
            {
                Console.WriteLine("Invalid choice");
            }
            IStudentServices services = new StudentServices(repo);
            bool status = true;
            while (status)
            {
                Console.WriteLine("1.Add Student \n2.View all \n3.Retrive by ID \n4.Update \n5.Delete \n6.exit \nChoice: ");
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();
                try
                {
                    switch(choice)
                    {
                        case 1: AddStudent(services); break;
                        case 2: ViewAllStudents(services); break;
                        case 3: ViewStudentById(services); break;
                        case 4: UpdateStudent(services); break;
                        case 5: DeleteStudent(services); break;
                        case 6: status = false; Console.WriteLine("Exiting"); break;
                        default: Console.WriteLine("Enter valid option"); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine();
            }
        }

        static void AddStudent(IStudentServices services)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Grade: ");
            int grade = int.Parse(Console.ReadLine());
            Student student = new Student { Name = name, Grade = grade };
            services.AddStudent(student);

            Console.WriteLine($"Student {student.StudentID} added");
        }

        static void ViewAllStudents(IStudentServices services)
        {
            IEnumerable<Student> students = services.GetStudents();
            if (!students.Any())
            {
                Console.WriteLine("No student found");
                return;
            }
            foreach (var item in students)
                Console.WriteLine("  " + item);
        }

        static void ViewStudentById(IStudentServices services)
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            Student student = services.GetStudent(id);
            Console.WriteLine(student);
        }

        static void UpdateStudent(IStudentServices services)
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            Student existing = services.GetStudent(id);
            Console.WriteLine("Existing details: " + existing);
            Console.Write("Enter new name  : ");
            string newName = Console.ReadLine();
            Console.Write("Enter new grade : ");
            int newGrade = int.Parse(Console.ReadLine());
            Student updated = new Student { StudentID = id, Name = newName, Grade = newGrade };
            services.UpdateStudent(updated);
            Console.WriteLine("Student updated");
        }

        static void DeleteStudent(IStudentServices services)
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            Student existing = services.GetStudent(id);
            Console.WriteLine($"Delete {existing}?");
            string confirm = Console.ReadLine();

            if (confirm == "y" || confirm == "yes" || confirm == "YES" || confirm == "Yes" || confirm == "Y")
            {
                services.DeleteStudent(id);
                Console.WriteLine("Student deleted");
            }
            else
            {
                Console.WriteLine("Deletion cancelled");
            }
        }
    }
}