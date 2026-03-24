using LayeredStudMgmtSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredStudMgmtSystem.Services
{
    internal interface IStudentServices
    {
        void AddStudent(Student student);
        Student GetStudent(int id);
        IEnumerable<Student> GetStudents();
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
    }
}
