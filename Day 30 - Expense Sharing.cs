using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10._2
{
    internal class Class1
    {
        static List<double> Calculate(int[] arr, string[] names)
        {
            List<double> result = new List<double>();
            double average = arr.Average();
            Console.WriteLine("Average : " + Math.Round(average));
            int max = Array.IndexOf(arr, arr.Max());
            foreach (int i in arr)
            {
                result.Add(i-average);
            }
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i] <= 0)
                {
                    if (result[i] == 0) Console.WriteLine($"{names[i]} does not pay or receive anything.");
                    Console.WriteLine($"{names[i]} pays {names[max]} {Math.Round(Math.Abs(result[i]))}");
                }
                else
                {
                    Console.WriteLine($"{names[max]} receives {Math.Round(result[i])}");
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            int[] arr = { 800, 1000, 900 };
            string[] names = { "ABC", "DEF", "GHI" };
            List<double> result = new List<double>();
            result = Calculate(arr, names);
        }
    }
}
