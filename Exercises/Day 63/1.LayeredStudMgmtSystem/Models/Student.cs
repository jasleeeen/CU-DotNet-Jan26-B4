using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredStudMgmtSystem.Models
{
    internal class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public override string ToString()
        {
            return $"ID: {StudentID}, Name: {Name}, Grade: {Grade}";
        }
    }
}
