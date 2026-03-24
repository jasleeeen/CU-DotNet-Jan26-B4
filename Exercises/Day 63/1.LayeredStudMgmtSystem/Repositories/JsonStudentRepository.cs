using LayeredStudMgmtSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace LayeredStudMgmtSystem.Repositories
{
    internal class JsonStudentRepository : IStudentRepository
    {
        private readonly string _path = @"..\..\..\students.json";
        public JsonStudentRepository()
        {
            if (!File.Exists(_path))
            {
                File.WriteAllText(_path, "[]");
            }
        }

        private List<Student> ReadFromFile()
        {
            string json = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
        }

        private void WriteToFile(List<Student> students)
        {
            string json = JsonSerializer.Serialize(students, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(_path, json);
        }

        public void Add(Student student)
        {
            var students = ReadFromFile();
            student.StudentID = students.Max(s => s.StudentID) + 1;
            students.Add(student);
            WriteToFile(students);
        }

        public IEnumerable<Student> GetAll()
        {
            return ReadFromFile();
        }

        public Student GetById(int id)
        {
            return ReadFromFile().FirstOrDefault(s => s.StudentID == id);
        }

        public void Update(Student updated)
        {
            var students = ReadFromFile();
            var student = students.FirstOrDefault(s => s.StudentID == updated.StudentID);
            if (student == null)
                throw new Exception("Student not found");
            student.Name = updated.Name;
            student.Grade = updated.Grade;
            WriteToFile(students);
        }

        public void Delete(int id)
        {
            var students = ReadFromFile();
            var student = students.FirstOrDefault(s => s.StudentID == id);
            if (student == null)
                throw new Exception("Student not found");
            students.Remove(student);
            WriteToFile(students);
        }
    }
}