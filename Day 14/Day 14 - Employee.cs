using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppOOPS
{
    internal class Employee
    {
        public int Id;
        public void Setter(int Id) { this.Id = Id; }
        public int Getter() { return Id; }

        public string Name { get; set; }

        private string department;
        public string Department
        {
            get { return department; }
            set
            {
                if (value == "Accounts" || value == "Sales" || value == "IT") department = value;
                else Console.WriteLine("Invalid Department.");
            }
        }

        private int salary;
        public int Salary
        {
            get { return salary; }
            set
            {
                if (value >= 50000 && value <= 90000) salary = value;
                else Console.WriteLine("Invalid Salary.");
            }
        }

        public void Display()
        {
            Console.WriteLine("\nEmployee Details");
            Console.WriteLine("Id: " + Getter());
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Department: " + Department);
            Console.WriteLine("Salary: " + Salary);
        }

        static void Main(string[] args)
        {
            Employee emp = new Employee();
            Console.Write("Enter Id: ");
            int id = int.Parse(Console.ReadLine());
            emp.Setter(id);

            Console.Write("Enter Name: ");
            emp.Name = Console.ReadLine();
            while (true)
            {
                Console.Write("Enter Department (Accounts/Sales/IT): ");
                string dept = Console.ReadLine();
                if (dept == "Accounts" || dept == "Sales" || dept == "IT")
                {
                    emp.Department = dept;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Department");
                }
            }
            while (true)
            {
                Console.Write("Enter Salary: ");
                int sal = int.Parse(Console.ReadLine());
                if (sal >= 50000 && sal <= 90000)
                {
                    emp.Salary = sal;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Salary");
                }
            }

            emp.Display();
        }
    }
}