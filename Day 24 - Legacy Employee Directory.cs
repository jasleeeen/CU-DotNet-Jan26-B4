using System.Collections;

namespace ConsoleApp3._2Ex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable employeeTable = new Hashtable();
            employeeTable.Add(101, "Alice");
            employeeTable.Add(102, "Bob");
            employeeTable.Add(103, "Charlie");
            employeeTable.Add(104, "Diana");
            if(!employeeTable.ContainsKey(105)) employeeTable.Add(105, "Edward");
            else Console.WriteLine("ID already exists.");
            string name = (string)employeeTable[102];
            Console.WriteLine($"Employee Name of Employee with ID 102 : {name}.\n");
            Console.WriteLine("Employee Table");
            foreach (DictionaryEntry item in employeeTable)
            {
                Console.WriteLine($"ID: {item.Key}, Name: {item.Value}");

            }
            employeeTable.Remove(103);
            Console.WriteLine("\nEmployee with ID 103 removed.\n");
            Console.WriteLine($"Employee Count: {employeeTable.Count}\n");

            foreach (DictionaryEntry item in employeeTable)
            {
                Console.WriteLine($"ID: {item.Key}, Name: {item.Value}");

            }
        }
    }
}
