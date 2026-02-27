using System;
namespace ConsoleApp27._1
{
    internal class Loan
    {
        public string LoanNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal PrincipalAmount { get; set; }
        public int TenureInYears { get; set; }
        public Loan(string loanNum, string custName, decimal prinAmount, int tenure)
        {
            LoanNumber = loanNum;
            CustomerName = custName;
            PrincipalAmount = prinAmount;
            TenureInYears = tenure;
            Console.WriteLine("Loan constructor called");
        }
        public static decimal CalculateEMI(decimal prinAmount, int tenure)
        {
            decimal totalAmount = prinAmount + (prinAmount * 0.10m * tenure);
            decimal emi = totalAmount / (tenure * 12);
            Console.WriteLine("Base class called");
            return emi;
        }
    }
    internal class HomeLoan : Loan
    {
        public HomeLoan(string loanNum, string custName, decimal prinAmount, int tenure)
            : base(loanNum, custName, prinAmount, tenure)
        {
            Console.WriteLine("HomeLoan constructor called");
        }
        public static new decimal CalculateEMI(decimal prinAmount, int tenure)
        {
            decimal processingFee = prinAmount * 0.01m;
            prinAmount += processingFee;

            decimal totalAmount = prinAmount + (prinAmount * 0.08m * tenure);
            decimal emi = totalAmount / (tenure * 12);
            Console.WriteLine("HomeLoan class called");
            return emi;
        }
    }
    internal class CarLoan : Loan
    {
        public CarLoan(string loanNum, string custName, decimal prinAmount, int tenure)
            : base(loanNum, custName, prinAmount, tenure)
        {
            Console.WriteLine("CarLoan constructor called");
        }
        public static new decimal CalculateEMI(decimal prinAmount, int tenure)
        {
            prinAmount += 15000;
            decimal totalAmount = prinAmount + (prinAmount * 0.09m * tenure);
            decimal emi = totalAmount / (tenure * 12);
            Console.WriteLine("CarLoan class called");
            return emi;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Loan[] loans = new Loan[4];
            loans[0] = new HomeLoan("H1", "Alice", 1000000, 15);
            loans[1] = new HomeLoan("H2", "Alicey", 1500000, 10);
            loans[2] = new CarLoan("C1", "Bob", 500000, 5);
            loans[3] = new CarLoan("C2", "Bobby", 780000, 7);
            for (int i = 0; i < loans.Length; i++)
            {
                decimal emi = Loan.CalculateEMI(loans[i].PrincipalAmount, loans[i].TenureInYears);
                Console.WriteLine($"EMI: {emi:F2}");
            }
        }
    }
}