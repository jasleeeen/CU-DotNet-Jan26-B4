//create class student props studid,studname, create dictionary to store student , record student and their marks
//dictionary<student,int> add student if not already exists, if existing and marks are more than existing then update marks
using StudentSomething;

namespace StudentSomething
{
    class Student
    {
        public int StudId { get; set; }
        public string StudName { get; set; }
        
        public override bool Equals(object? obj)
        {
            Student stemp = obj as Student;
            return this.StudId == stemp.StudId && this.StudName == stemp.StudName;
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(StudId, StudName);
        }
        public override string ToString()
        {
            return $"{StudId} {StudName}";
        }
    }
    class Manager
    {
        private Dictionary<Student, int> dict = new Dictionary<Student, int>();
        public void UpdateMarks(Student s, int marks)
        {
            if (!dict.ContainsKey(s))
            {
                dict.Add(s, marks);
            }
            else
            {
                if (marks > dict[s])
                {
                    dict[s] = marks;
                }
            }
        }
        public void Display()
        {
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key.StudId} - {item.Key.StudName} - {item.Value}");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            Student s1 = new Student { StudId = 1, StudName = "ABC" };
            manager.UpdateMarks(s1, 77);
            manager.UpdateMarks(new Student
            {
                StudId = 2,
                StudName = "DEF"
            }, 88);
            Student s3 = new Student { StudId = 3, StudName = "GHI" };
            manager.UpdateMarks(s1, 65);
            Student s4 = new Student { StudId = 3, StudName = "GHI" };
            manager.UpdateMarks(s4, 67);
            manager.Display();
        }
    }
}