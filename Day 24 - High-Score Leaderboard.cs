using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3._2Ex
{
    internal class High_Score_Leaderboard
    {
        static void Main(string[] args)
        {
            SortedDictionary<double, string> leaderboard = new SortedDictionary<double, string>();
            leaderboard.Add(55.42, "SwiftRacer");
            leaderboard.Add(52.10, "SpeedDemon");
            leaderboard.Add(58.91, "SteadyEddie");
            leaderboard.Add(51.05, "TurboTom");
            Console.WriteLine("Leaderboard ");
            foreach (var item in leaderboard)
            {
                Console.WriteLine($"Lap Time: {item.Key,-5:F2}, Name: {item.Value}");
            }
            var fastest = leaderboard.First();
            Console.WriteLine($"\nFastest Lap Time: \nName: {fastest.Value}\nTime: {fastest.Key:F2}\n");
            Console.WriteLine("SteadyEddie's improved time: 54.00\n");
            leaderboard.Remove(58.91);
            leaderboard.Add(54.00, "SteadyEddie");
            Console.WriteLine("Leaderboard ");
            foreach (var item in leaderboard)
            {
                Console.WriteLine($"Lap Time: {item.Key, -5:F2}, {"Name"}: {item.Value}");
            }
        }
    }
}
