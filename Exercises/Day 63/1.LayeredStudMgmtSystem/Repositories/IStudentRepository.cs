using LayeredStudMgmtSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredStudMgmtSystem.Repositories
{
    internal interface IStudentRepository
    {
            void Add(Student student);
            Student GetById(int id);  
            IEnumerable<Student> GetAll();
            void Update(Student student); 
            void Delete(int id);
    }
}