namespace Weekly_Sales_Analysis_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal[] arr = new decimal[7];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"Enter sales for day {i+1}: ");
                arr[i] = decimal.Parse(Console.ReadLine());
                while (arr[i] < 0) arr[i] = decimal.Parse(Console.ReadLine());
            }
            decimal sum = arr.Sum();
            decimal avg = sum / arr.Length;
            decimal highestSales = arr.Max();
            int dayOfHighestSales = Array.IndexOf(arr, highestSales) + 1;
            decimal lowestSales = arr.Min();
            int dayOfLowestSales = Array.IndexOf(arr, lowestSales) + 1;
            string[] salesCat = new string[7];

            for (int i = 0;i < arr.Length;i++)
            {
                if (arr[i] < 5000)
                {
                    salesCat[i] = "Low";
                }
                else if (arr[i] >= 5000 && arr[i] <= 15000)
                {
                    salesCat[i] = "Medium";
                }
                else
                {
                    salesCat[i] = "High";
                }
            }
            int count = 0;
            for (int i = 0; i < arr.Length;i++)
            {
                if ((arr[i] > avg)) { count++; }
            }

            Console.WriteLine("-----------------------------");
            Console.WriteLine("\nWeekly Sales Report");
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"{"Total Sales :",-15} {sum}");
            Console.WriteLine($"{"Average Daily Sale :",-15} {avg:F2}");
            Console.WriteLine($"{"Highest Sale :",-15} {highestSales} (Day {dayOfHighestSales})");
            Console.WriteLine($"{"Lowest Sale :",-15} {lowestSales} (Day {dayOfLowestSales})");
            Console.WriteLine($"{"Days Above Average :",-15} {count}");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Day-wise sales category summary: ");
            for (int i = 1; i <= 7 ; i++)
            {
                Console.WriteLine($"Day {i} : {salesCat[i-1]}");
            }

        }
    }
}
