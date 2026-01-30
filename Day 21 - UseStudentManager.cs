using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// create an entity class student with prop id name marks. create studentmanager class to manage student database in terms of dictionary<int, Student> the class should facilitate CRUD operations like add delete display search . create use student manager
namespace ConsoleApp30._1
{
    class Student   //Entity class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Marks { get; set; }
        public override string ToString()
        {
            return $"ID : {Id}, Name : {Name}, Marks : {Marks}";
        }
    }

    class StudentManager
    {
        Dictionary<int, Student> studentData = new Dictionary<int, Student>();
        public bool AddStudent(Student student)
        {
            if (!studentData.ContainsKey(student.Id))
            {
                studentData.Add(student.Id, student);
                return true;
            }
            return false;
        }

        public Student SearchStudent(int id)
        {
            Student student = null;
            bool found = studentData.TryGetValue(id, out student);
            return student;
        }

        public bool UpdateStudent(int id, int marks)
        {
            Student foundStudent = SearchStudent(id);
            if (foundStudent != null)
            {
                foundStudent.Marks = marks;
                return true;
            }
            return false;
        }

        public bool DeleteStudent(int id)
        {
            return studentData.Remove(id);
        }
        public void DisplayAllStudents()
        {
            foreach (var student in studentData)
            {
                Console.WriteLine(student.Value);
            }
        }
    }

    internal class UseStudentManager
    {
        static void Main(string[] args)
        {
            //StudentManager manager = new StudentManager();
            //manager.AddStudent(new Student()
            //{
            //    Id = 101,
            //    Name = "S1",
            //    Marks = 100
            //});
            //manager.AddStudent(new Student()
            //{
            //    Id = 111,
            //    Name = "S2",
            //    Marks = 90
            //});
            //manager.DisplayAllStudents();
            //Console.WriteLine();
            //Student foundstudent = manager.SearchStudent(111);
            //if (foundstudent == null) Console.WriteLine("Student not found");
            //else Console.WriteLine(foundstudent);
            //Console.WriteLine();
            //manager.DisplayAllStudents();
            //Console.WriteLine();
            //bool updated = manager.UpdateStudent(101, 80);
            //if (updated) Console.WriteLine(manager.SearchStudent(111));
            //manager.DisplayAllStudents();
            //Console.WriteLine();
            //bool deleted = manager.DeleteStudent(112);
            //if (deleted) Console.WriteLine("deleted");
            //manager.DisplayAllStudents();


            StudentManager manager = new StudentManager();
            int choice;
            Console.WriteLine("STUDENT MANAGEMENT");
            Console.WriteLine("1. Add Student\n2. Search Student\n3. Update Student Marks\n4. Delete Student\n5. Display All Students\n6. Exit\n");
            do
            {
                Console.WriteLine("Enter choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Student s = new Student();
                        Console.Write("Enter ID: ");
                        s.Id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Name: ");
                        s.Name = Console.ReadLine();
                        Console.Write("Enter Marks: ");
                        s.Marks = int.Parse(Console.ReadLine());
                        if (manager.AddStudent(s))
                            Console.WriteLine("Student added successfully.");
                        else
                            Console.WriteLine("Student with this ID already exists.");
                        break;

                    case 2:
                        Console.Write("Enter ID to search: ");
                        int searchId = int.Parse(Console.ReadLine());
                        Student found = manager.SearchStudent(searchId);
                        if (found == null)
                            Console.WriteLine("Student not found.");
                        else
                            Console.WriteLine(found);
                        break;

                    case 3:
                        Console.Write("Enter ID to update: ");
                        int updateId = int.Parse(Console.ReadLine());
                        Console.Write("Enter new marks: ");
                        int newMarks = int.Parse(Console.ReadLine());
                        if (manager.UpdateStudent(updateId, newMarks))
                            Console.WriteLine("Marks updated successfully.");
                        else
                            Console.WriteLine("Student not found.");
                        break;

                    case 4:
                        Console.Write("Enter ID to delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        if (manager.DeleteStudent(deleteId))
                            Console.WriteLine("Student deleted successfully.");
                        else
                            Console.WriteLine("Student not found.");
                        break;

                    case 5:
                        manager.DisplayAllStudents();
                        break;

                    case 6:
                        Console.WriteLine("Exiting");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
                Console.WriteLine();
            } while (choice != 6);
        }
    }
}