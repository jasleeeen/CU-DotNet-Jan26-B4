using LayeredStudMgmtSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredStudMgmtSystem.Repositories
{
    internal class ListStudentRepository : IStudentRepository
    {
        private readonly List<Student> _students = new List<Student>();
        private int _ID = 1;

        public void Add(Student student)
        {
            student.StudentID = _ID++;
            _students.Add(student);
        }

        public Student GetById(int id)
        {
            return _students.FirstOrDefault(s => s.StudentID == id);
        }

        public IEnumerable<Student> GetAll()
        {
            return _students.ToList();
        }

        public void Update(Student updated)
        {
            var existing = _students.FirstOrDefault(s => s.StudentID == updated.StudentID);
            if (existing == null)
                throw new Exception($"Student not found.");
            existing.Name = updated.Name;
            existing.Grade = updated.Grade;
        }

        public void Delete(int id)
        {
            var student = _students.FirstOrDefault(s => s.StudentID == id);
            if (student == null)
                throw new Exception($"Student  not found.");
            _students.Remove(student);
        }
    }
}
