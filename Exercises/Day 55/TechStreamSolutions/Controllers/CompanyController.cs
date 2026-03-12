using Microsoft.AspNetCore.Mvc;
using TechStreamSolutions.Models;

namespace TechStreamSolutions.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee{ Id = 1, Name="ABC", Position="SDE", Salary=50000 },
                new Employee{ Id = 2, Name="BCD", Position="Manager", Salary=90000 },
                new Employee{ Id = 3, Name="CDE", Position="SDE", Salary=60000 },
                new Employee{ Id = 4, Name="EFG", Position="Tester", Salary=55000 }
            };
            ViewBag.Announcement = "System update at 8 PM";
            ViewData["DeptName"] = "Development";
            ViewData["ServerStatus"] = true;
            return View(employees);
        }
    }
}
