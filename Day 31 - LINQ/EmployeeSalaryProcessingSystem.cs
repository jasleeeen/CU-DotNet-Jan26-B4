using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11._2
{
    class Employee
    {
        public int Id;
        public string Name;
        public string Dept;
        public double Salary;
        public DateTime JoinDate;
    }
    internal class EmployeeSalaryProcessingSystem
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee>
            {
                new Employee{Id=1, Name="Ravi", Dept="IT", Salary=80000, JoinDate=new DateTime(2019,1,10)},
                new Employee{Id=2, Name="Anita", Dept="HR", Salary=60000, JoinDate=new DateTime(2021,3,5)},
                new Employee{Id=3, Name="Suresh", Dept="IT", Salary=120000, JoinDate=new DateTime(2018,7,15)},
                new Employee{Id=4, Name="Meena", Dept="Finance", Salary=90000, JoinDate=new DateTime(2022,9,1)}
            };
            Console.WriteLine("Get highest and lowest salary in each department");
            var highestSal = employees.Max(e => e.Salary);
            Console.WriteLine("Highest Salary : " + highestSal);
            var lowestSal = employees.Min(e => e.Salary);
            Console.WriteLine("Lowest Salary : " + lowestSal);

            Console.WriteLine("\nCount employees per department");
            var countPerDept = employees.GroupBy(e => e.Dept).Select(e=> new { 
                Dept = e.Key, Count = e.Count()
            });
            foreach (var item in countPerDept)
            {
                Console.WriteLine($"{item.Dept} - {item.Count}");
            }

            Console.WriteLine("\nFilter employees joined after 2020");
            var empAfter2020 = employees.Where(e => e.JoinDate.Year > 2020);
            foreach (var item in empAfter2020)
            {
                Console.WriteLine($"{item.Name} - {item.Dept} - {item.JoinDate.Year}");
            }

            Console.WriteLine("\nProject anonymous objects with Name and AnnualSalary");
            var projection = employees.Select(e=> new
            {
                Name = e.Name,
                AnnualSalary = e.Salary *12,
            });
            foreach (var item in projection)
            {
                Console.WriteLine($"{item.Name} - {item.AnnualSalary}");
            }
        }
    }
}
