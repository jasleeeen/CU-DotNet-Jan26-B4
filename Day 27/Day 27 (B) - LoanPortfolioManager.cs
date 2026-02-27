using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDay27_01_DailyLogger
{
    public class Loan
    {
        public string ClientName { get; set; }
        public double Principal { get; set; }
        public double InterestRate { get; set; }

        public double CalculateInterest()
        {
            return (Principal * InterestRate) / 100;
        }

        public string GetRiskCategory()
        {
            if (InterestRate > 10)
                return "High Risk";
            else if (InterestRate >= 5)
                return "Medium Risk";
            else
                return "Low Risk";
        }
    }

    internal class LoanPortfolioManager
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string filePath = @"..\..\..\loans.csv";
            Console.Write("Enter Client Name : ");
            string name = Console.ReadLine();
            Console.Write("Enter Principal Amount : ");
            string principalInput = Console.ReadLine();
            Console.Write("Enter Interest Rate : ");
            string rateInput = Console.ReadLine();
            if (!double.TryParse(principalInput, out double principal) || !double.TryParse(rateInput, out double rate))
            {
                Console.WriteLine("Invalid input. Loan not saved.");
                return;
            }
            bool fileExists = File.Exists(filePath);
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                if (!fileExists)
                    writer.WriteLine("ClientName,Principal,InterestRate");
                writer.WriteLine($"{name},{principal},{rate}");
            }
            Console.WriteLine("\nLoan saved");
            if (!File.Exists(filePath))
            {
                Console.WriteLine("No loan data found.");
                return;
            }
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length != 3)
                        continue;
                    if (!double.TryParse(parts[1], out double principalAmt) || !double.TryParse(parts[2], out double rateOI))
                        continue;
                    Loan loan = new Loan
                    {
                        ClientName = parts[0],
                        Principal = principalAmt,
                        InterestRate = rateOI
                    };
                    Console.WriteLine($"Client: {loan.ClientName} | Principal: {loan.Principal:C} | Rate: {loan.InterestRate}% | Interest: {loan.CalculateInterest():C} | Risk: {loan.GetRiskCategory()}"
                    );
                }
            }
        }
    }
}