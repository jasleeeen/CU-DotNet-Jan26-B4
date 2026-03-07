using System.Numerics;

namespace Cricket_Player_Performance_Tracker
{
    class Player
    {
        public string Name { get; set; }
        public int RunsScored { get; set; }
        public int BallsFaced { get; set; }
        public bool IsOut { get; set; }

        public double StrikeRate { get; set; }
        public double Average { get; set; }

        public void CalculateStats()
        {
            if (BallsFaced == 0)
                StrikeRate = 0;
            else
                StrikeRate = (double)RunsScored / BallsFaced * 100;
            Average = RunsScored;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter CSV file path: ");
            string path = Console.ReadLine();
            List<Player> players = new List<Player>();
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    try
                    {
                        string[] parts = line.Split(',');
                        string name = parts[0].Trim();
                        int runs = int.Parse(parts[1].Trim());
                        int balls = int.Parse(parts[2].Trim());
                        bool isOut = bool.Parse(parts[3].Trim());
                        Player player = new Player
                        {
                            Name = name,
                            RunsScored = runs,
                            BallsFaced = balls,
                            IsOut = isOut
                        };
                        player.CalculateStats();
                        players.Add(player);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Invalid line: {line}");
                    }
                }
                var finalList = players
                        .Where(p => p.BallsFaced >= 10)
                        .OrderBy(p => p.StrikeRate)
                        .Reverse()
                        .ToList();
                DisplayTable(finalList);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void DisplayTable(List<Player> players)
        {
            Console.WriteLine();
            Console.WriteLine($"{"Name",-15}{"Runs",-8}{"SR",-8}{"Avg",-8}");
            foreach (var p in players)
            {
                Console.WriteLine($"{p.Name,-15}{p.RunsScored,-8}{p.StrikeRate,-8:F2}{p.Average,-8:F2}");
            }
        }
    }
}