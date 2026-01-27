using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp27._1
{
    internal class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public decimal BasicSalary { get; set; }
        public int ExperienceInYears { get; set; }
        public Employee(int empID, string empName, decimal basicSalary, int expInYears)
        {
            EmployeeID = empID;
            EmployeeName = empName;
            BasicSalary = basicSalary;
            ExperienceInYears = expInYears;
        }
        public decimal CalculateAnnualSalary()
        {
            decimal AnnualSalary = BasicSalary * 12;
            return AnnualSalary;
        }
        public void DisplayEmployeeDetails()
        {
            Console.WriteLine($"Employee ID : {EmployeeID}, Employee Name : {EmployeeName}, Experience In Years : {ExperienceInYears} , Annual Salary : {CalculateAnnualSalary()}");
        }
    }


    internal class PermanentEmployee : Employee
    {
        public PermanentEmployee(int empID, string empName, decimal basicSalary, int expInYears) : base(empID, empName, basicSalary, expInYears)
        {
            Console.WriteLine("PermanentEmployee constructor called");
        }
        public new decimal CalculateAnnualSalary()
        {
            decimal houseRentAllowance = 0.2m * BasicSalary;
            decimal specialAllowance = 0.1m * BasicSalary;
            decimal loyaltyBonus = 0;
            if (ExperienceInYears >= 5) loyaltyBonus = 50000m;
            decimal AnnualSalary = ((BasicSalary + houseRentAllowance + specialAllowance)*12) + loyaltyBonus;
            return AnnualSalary;
        }
        public new void DisplayEmployeeDetails()
        {
            Console.WriteLine($"Employee ID : {EmployeeID}, Employee Name : {EmployeeName}, Experience In Years : {ExperienceInYears} , Annual Salary : {CalculateAnnualSalary()}");
        }
    }


    internal class ContractEmployee : Employee
    {
        public int ContractDurationInMonths { get; set; }
        public ContractEmployee(int empID, string empName, decimal basicSalary, int expInYears, int contractDuration) : base(empID, empName, basicSalary, expInYears)
        {
            ContractDurationInMonths = contractDuration;
            Console.WriteLine("ContractEmployee constructor called");
        }
        public new decimal CalculateAnnualSalary()
        {
            int contractCompletionBonus = 0;
            if (ContractDurationInMonths >= 12) contractCompletionBonus = 30000;
            decimal AnnualSalary = (BasicSalary * 12) + contractCompletionBonus;
            return AnnualSalary;
        }
        public new void DisplayEmployeeDetails()
        {
            Console.WriteLine($"Employee ID : {EmployeeID}, Employee Name : {EmployeeName}, Experience In Years : {ExperienceInYears} , Annual Salary : {CalculateAnnualSalary()}, Contract Duration : {ContractDurationInMonths}");
        }
    }


    internal class InternEmployee : Employee
    {
        public InternEmployee(int empID, string empName, decimal stipend, int expInYears) : base(empID, empName, stipend, expInYears)
        {
            Console.WriteLine("InternEmployee constructor called");
        }
        public new decimal CalculateAnnualSalary()
        {
            decimal AnnualSalary = BasicSalary * 12;
            return AnnualSalary;
        }
        public new void DisplayEmployeeDetails()
        {
            Console.WriteLine($"Employee ID : {EmployeeID}, Employee Name : {EmployeeName}, Experience In Years : {ExperienceInYears} , Annual Salary/Stipend : {CalculateAnnualSalary()}");
        }
    }


    internal class Employee_Compensation_Management_System
    {
        static void Main(string[] args)
        {
            Employee e1 = new Employee(1, "A", 500000, 2);
            Employee e2 = new PermanentEmployee(2, "B", 500000, 2);
            PermanentEmployee e3 = new PermanentEmployee(3, "C", 700000, 3);
            ContractEmployee e4 = new ContractEmployee(4, "D", 60000, 2, 14);
            InternEmployee e5 = new InternEmployee(5, "E", 25000, 0);
            e1.DisplayEmployeeDetails();
            e2.DisplayEmployeeDetails();
            e3.DisplayEmployeeDetails();
            e4.DisplayEmployeeDetails();
            e5.DisplayEmployeeDetails();
        }

    }
}
