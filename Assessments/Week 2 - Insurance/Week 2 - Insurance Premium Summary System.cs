namespace Insurance_Premium_Summary_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] policyHolderNames = new string[5];
            decimal[] annualPremiums = new decimal[5];
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter name of policy holder {i + 1}: ");
                policyHolderNames[i] = Console.ReadLine();
                while (policyHolderNames[i]=="")
                {
                    Console.WriteLine("Invalid name.");
                    policyHolderNames[i] = Console.ReadLine();
                }
                Console.Write($"Enter the annual premium for policy holder {i + 1}: ");
                annualPremiums[i] = decimal.Parse(Console.ReadLine());
                while (annualPremiums[i]<=0)
                {
                    Console.WriteLine("Invalid premium.");
                    annualPremiums[i] = decimal.Parse(Console.ReadLine());
                }
                Console.WriteLine();
            }
            decimal total = CalTotalPremium(annualPremiums);
            decimal average = CalAveragePremium(total);
            decimal highest = CalHighestPremium(annualPremiums);
            decimal lowest = CalLowestPremium(annualPremiums);
            PrintReport(policyHolderNames, annualPremiums, total, average, highest, lowest);
        }
        static decimal CalTotalPremium(decimal[] annualPremiums)
        {
            decimal total = annualPremiums.Sum();
            return total;
        }
        static decimal CalAveragePremium(decimal total)
        {
            return (total / 5.0m);
        }
        static decimal CalHighestPremium(decimal[] annualPremiums)
        {
            return annualPremiums.Max();
        }
        static decimal CalLowestPremium(decimal[] annualPremiums)
        {
            return annualPremiums.Min();
        }
        static void PrintReport(string[] policyHolderNames, decimal[] annualPremiums, decimal total, decimal average, decimal highest, decimal lowest)
        {
            Console.WriteLine("Insurance Premium Summary");
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"{"Name",-10}{"Premium",-10}{"Category",-10}");
            Console.WriteLine("---------------------------------");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"{policyHolderNames[i].ToUpper(),-10}{annualPremiums[i],-10:F2}");
                string category;
                if (annualPremiums[i] < 10000)
                    category = "LOW";
                else if (annualPremiums[i] >= 10000 && annualPremiums[i] <= 25000)
                    category = "MEDIUM";
                else
                    category = "HIGH";
                Console.WriteLine($"{category,-10}");
            }
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"{"Total Premium", -20}: {total:F2}");
            Console.WriteLine($"{"Average Premium",-20}: {average:F2}");
            Console.WriteLine($"{"Highest Premium",-20}: {highest:F2}");
            Console.WriteLine($"{"Lowest Premium",-20}: {lowest:F2}");
        }

    }
}
