using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11._2
{
    class Student
    {
        public int Id;
        public string Name;
        public string Class;
        public int Marks;
    }
    internal class StudentPerformanceAnalytics
    {
        static void Main(string[] args)
        {
            var students = new List<Student> 
            {
                new Student{Id=1, Name="Amit", Class="10A", Marks=85},
                new Student{Id=2, Name="Neha", Class="10A", Marks=72},
                new Student{Id=3, Name="Rahul", Class="10B", Marks=90},
                new Student{Id=4, Name="Pooja", Class="10B", Marks=60},
                new Student{Id=5, Name="Kiran", Class="10A", Marks=95}
            };

            Console.WriteLine("Get top 3 students by marks");
            var top3Students = students.OrderByDescending(s => s.Marks).Take(3);
            foreach (var student in top3Students)
            {
                Console.WriteLine(student.Name + " " + student.Marks);
            }

            Console.WriteLine("Group students by Class and calculate average marks");
            var avgInClass = students.GroupBy(g => g.Class)
                .Select(g => new { Class = g.Key, Avg = g.Average(s => s.Marks) } );
            foreach (var avg in avgInClass)
            {
                Console.WriteLine($"{avg.Class} - {avg.Avg}");
            }

            Console.WriteLine("List students who scored below class average");
            var avgInClassDict = students.GroupBy(g => g.Class)
                .ToDictionary(g => g.Key, g => g.Average(s => s.Marks) );
            var belowAverage = students.Where(s=>s.Marks < avgInClassDict[s.Class]);
            foreach (var item in belowAverage)
            {
                Console.WriteLine($"{item.Name} - {item.Class} - {item.Marks}");
            }

            var belowAvg = students.Where(s => s.Marks < (students.Where(x => x.Class == s.Class).Average(a => a.Marks)));  //costly, more execution time as it will calculate average for each



            Console.WriteLine("Order students by Class then by Marks descending");
            //var orderByClassAndMarks = students.OrderBy(s => s.Class).OrderByDescending(s=>s.Marks);
            var orderByClassAndMarks = students.OrderBy(s => s.Class).ThenByDescending(s => s.Marks);
            foreach (var item in orderByClassAndMarks)
            {
                Console.WriteLine($"{item.Name} - {item.Class} - {item.Marks}");
            }
        }
    }
}
