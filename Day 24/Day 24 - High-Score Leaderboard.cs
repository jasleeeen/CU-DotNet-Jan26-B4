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
            Console.Write("Enter player whose time needs to be changed: ");
            string playerName = Console.ReadLine();
            Console.Write("Enter new lap time: ");
            double newTime = double.Parse(Console.ReadLine());
            bool found = false;
            double oldTime = 0;
            foreach (var entry in leaderboard)
            {
                if (entry.Value.Equals(playerName))
                {
                    oldTime = entry.Key;
                    found = true;
                    break;
                }
            }

            if (found)
            {
                leaderboard.Remove(oldTime);
                leaderboard.Add(newTime, playerName);
            }
            Console.WriteLine("Leaderboard ");
            foreach (var item in leaderboard)
            {
                Console.WriteLine($"Lap Time: {item.Key, -5:F2}, {"Name"}: {item.Value}");
            }
        }
    }
}
