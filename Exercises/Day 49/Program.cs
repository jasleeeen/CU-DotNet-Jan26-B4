using System;
using System.Collections.Generic;
using System.Linq;
namespace CollegeManagementSystem
{
    class CollegeManagement
    {
        Dictionary<string, Dictionary<string, int>> studentRecords = new Dictionary<string, Dictionary<string, int>>();
        Dictionary<string, LinkedList<KeyValuePair<string, int>>> studentSubjectsOrder = new Dictionary<string, LinkedList<KeyValuePair<string, int>>>();
        Dictionary<string, Dictionary<string, int>> subjectsRecords = new Dictionary<string, Dictionary<string, int>>();
        Dictionary<string, LinkedList<KeyValuePair<string, int>>> subjectsStudentsOrder = new Dictionary<string, LinkedList<KeyValuePair<string, int>>>();
        public void AddStudent(string studentId, string subject, int marks)
        {
            if (!studentRecords.ContainsKey(studentId))
            {
                studentRecords[studentId] = new Dictionary<string, int>();
                studentSubjectsOrder[studentId] = new LinkedList<KeyValuePair<string, int>>();
            }
            if (!subjectsRecords.ContainsKey(subject))
            {
                subjectsRecords[subject] = new Dictionary<string, int>();
                subjectsStudentsOrder[subject] = new LinkedList<KeyValuePair<string, int>>();
            }
            if (studentRecords[studentId].ContainsKey(subject))
            {
                if (marks > studentRecords[studentId][subject])
                {
                    studentRecords[studentId][subject] = marks;
                    subjectsRecords[subject][studentId] = marks;
                }
            }
            else
            {
                studentRecords[studentId][subject] = marks;
                subjectsRecords[subject][studentId] = marks;
                studentSubjectsOrder[studentId].AddLast(new KeyValuePair<string, int>(subject, marks));
                subjectsStudentsOrder[subject].AddLast(new KeyValuePair<string, int>(studentId, marks));
            }
        }

        public void RemoveStudent(string studentId)
        {
            foreach (var subject in studentRecords[studentId].Keys)
            {
                subjectsRecords[subject].Remove(studentId);
            }
            studentRecords.Remove(studentId);
            studentSubjectsOrder.Remove(studentId);
        }

        public string TopStudent(string subject)
        {
            if (!subjectsRecords.ContainsKey(subject))
                return "";
            int maxMarks = subjectsRecords[subject].Values.Max();
            List<string> result = new List<string>();
            foreach (var pair in subjectsStudentsOrder[subject])
            {
                if (subjectsRecords[subject].ContainsKey(pair.Key) && subjectsRecords[subject][pair.Key] == maxMarks)
                {
                    result.Add(pair.Key + " " + maxMarks);
                }
            }
            Console.WriteLine("Top students in subject: ");
            return string.Join("\n", result);
        }

        public string Result()
        {
            List<string> output = new List<string>();
            foreach (var student in studentRecords)
            {
                double avg = student.Value.Values.Average();
                output.Add($"{student.Key} {avg.ToString("F2")}");
            }
            return string.Join("\n", output);
        }
    }
    public class Program
    {   
        public static void Main()
        {
            CollegeManagement cm = new CollegeManagement();
            while (true)
            {
                Console.Write("Enter input: ");
                string input = Console.ReadLine();
                string[] parts = input.ToUpper().Split();
                var func = parts[0];
                if (func == "ADD")
                {
                    cm.AddStudent(parts[1], parts[2], int.Parse(parts[3]));
                }
                else if (func == "REMOVE")
                {
                    cm.RemoveStudent(parts[1]);
                }
                else if (func == "TOP")
                {
                    Console.WriteLine(cm.TopStudent(parts[1]));
                }
                else if (func == "RESULT")
                {
                    Console.WriteLine(cm.Result());
                }
                Console.WriteLine();
            }
        }
    }
}
