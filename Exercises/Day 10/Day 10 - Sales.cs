namespace Sales_Order_Processing_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal[] weeklySales = new decimal[7];
            string[] categories = new string[7];
            ReadWeeklySales(weeklySales);
            decimal total = CalculateTotal(weeklySales);
            decimal average = CalculateAverage(total, 7);
            decimal highestSale = FindHighestSale(weeklySales);
            int dayOfHighest = Array.IndexOf(weeklySales, highestSale) + 1;
            decimal lowestSale = FindLowestSale(weeklySales);
            int dayOfLowest = Array.IndexOf(weeklySales, lowestSale) + 1;
            Console.WriteLine("Is this a festival week? (true/false): ");
            bool isFestivalWeek = IsFestivalInput();
            decimal discount = CalculateDiscount(total, isFestivalWeek);
            decimal discountedAmount = total - discount;
            decimal tax = CalculateTax(discountedAmount);
            decimal finalPayable = CalculateFinalAmount(total, discount, tax);
            GenerateSalesCategory(weeklySales, categories);
            PrintReport(total, average, highestSale, dayOfHighest, lowestSale, dayOfLowest,
                        discount, tax, finalPayable, categories);
        }
        static void ReadWeeklySales(decimal[] sales)
        {
            for (int i = 0; i < sales.Length; i++)
            {
                Console.WriteLine($"Enter sales for Day {i + 1}: ");
                sales[i] = int.Parse(Console.ReadLine());
                while(sales[i] < 0)
                {
                    sales[i] = int.Parse(Console.ReadLine());
                }
            }
        }
        static bool IsFestivalInput()
        {
            string input = Console.ReadLine();
            bool result;
            bool.TryParse(input, out result);
            return result;
        }

        static decimal CalculateTotal(decimal[] sales)
        {
            decimal total = sales.Sum();
            return total;
        }
        static decimal CalculateAverage(decimal total, int days)
        {
            decimal average = total/days;
            return average;
        }
        static decimal FindHighestSale(decimal[] sales)
        {
            decimal highest = sales.Max();
            return highest;
        }
        static decimal FindLowestSale(decimal[] sales)
        {
            decimal lowest = sales.Min();
            return lowest;
        }
        static decimal CalculateDiscount(decimal total)
        {
            if (total >= 50000)
                return total * 0.10m;
            else
                return total * 0.05m;
        }
        static decimal CalculateDiscount(decimal total, bool isFestivalWeek)
        {
            decimal discount = CalculateDiscount(total);
            if (isFestivalWeek)
                discount += total * 0.05m;
            return discount;
        }
        static decimal CalculateTax(decimal amount)
        {
            return amount * 0.18m;
        }
        static decimal CalculateFinalAmount(decimal total, decimal discount, decimal tax)
        {
            return total - discount + tax;
        }
        static void GenerateSalesCategory(decimal[] sales, string[] categories)
        {
            for (int i = 0; i < sales.Length; i++)
            {
                if (sales[i] < 5000) categories[i] = "Low";
                else if (sales[i] <= 15000) categories[i] = "Medium";
                else categories[i] = "High";
            }
        }
        static void PrintReport(decimal total, decimal average,
                                decimal highestSale, int dayOfHighest,
                                decimal lowestSale, int dayOfLowest,
                                decimal discount, decimal tax, decimal finalPayable,
                                string[] categories)
        {
            Console.WriteLine();
            Console.WriteLine("Weekly Sales Summary");
            Console.WriteLine("--------------------");
            Console.WriteLine($"Total Sales        : {total:F2}");
            Console.WriteLine($"Average Daily Sale : {average:F2}");
            Console.WriteLine();
            Console.WriteLine($"Highest Sale       : {highestSale:F2} (Day {dayOfHighest})");
            Console.WriteLine($"Lowest Sale        : {lowestSale:F2}  (Day {dayOfLowest})");
            Console.WriteLine();
            Console.WriteLine($"Discount Applied   : {discount:F2}");
            Console.WriteLine($"Tax Amount         : {tax:F2}");
            Console.WriteLine($"Final Payable      : {finalPayable:F2}");
            Console.WriteLine();
            Console.WriteLine("Day-wise Category:");
            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine($"Day {i + 1} : {categories[i]}");
            }
        }
    }
}