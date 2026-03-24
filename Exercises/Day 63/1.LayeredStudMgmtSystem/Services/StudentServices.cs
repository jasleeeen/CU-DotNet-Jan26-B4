using LayeredStudMgmtSystem.Models;
using LayeredStudMgmtSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredStudMgmtSystem.Services
{
    internal class StudentServices : IStudentServices
    {
        private IStudentRepository _repository;
        public StudentServices(IStudentRepository repository)
        {
            _repository = repository;
        }

        public void AddStudent(Student student)
        {
            if(string.IsNullOrWhiteSpace(student.Name)) throw new Exception("Student name cannot be empty.");
            if (student.Grade < 0 || student.Grade > 100) throw new Exception("Grade must be between 0 and 100.");
            _repository.Add(student);
        }

        public Student GetStudent(int id)
        {
            Student student = _repository.GetById(id);
            if (student == null)
                throw new Exception($"Student not found");
            return student;
        }

        public IEnumerable<Student> GetStudents()
        {
            return _repository.GetAll();
        }

        public void UpdateStudent(Student student)
        {
            if (string.IsNullOrWhiteSpace(student.Name)) throw new Exception("Student name cannot be empty.");
            if (student.Grade < 0 || student.Grade > 100) throw new Exception("Grade must be between 0 and 100.");
            _repository.Update(student);
        }

        public void DeleteStudent(int id)
        {
            _repository.Delete(id);
        }
    }
}