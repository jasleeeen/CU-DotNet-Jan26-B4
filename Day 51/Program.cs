namespace StreamBuzz
{
    class CreatorStats
    {
        public string CreatorName { get; set; }
        public double[] WeeklyLikes { get; set; }
    }
    internal class Program
    {
        public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();
        public static void RegisterCreator(CreatorStats record)
        {
            EngagementBoard.Add(record);
        }

        public static Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach (var item in records)
            {
                int count = 0;
                foreach (var like in item.WeeklyLikes)
                {
                    if (like >= likeThreshold) count++;
                }
                if(count > 0)
                {
                    result[item.CreatorName] = count;
                }
            }
            return result;
        }

        public static double CalculateAverageLikes()
        {
            if (EngagementBoard.Count == 0) return 0;
            return EngagementBoard.SelectMany(c => c.WeeklyLikes).Average();
        }

        static void Main(string[] args)
        {
            Console.WriteLine(@"1. Register Creator
2. Show Top Posts
3. Calculate Average Likes
4. Exit
");
            bool terminate = false;
            while (!terminate)
            {
                Console.WriteLine("Enter your choice:");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        CreatorStats stats = new CreatorStats();
                        Console.WriteLine("Enter the Creator Name : ");
                        stats.CreatorName = Console.ReadLine();
                        Console.WriteLine("Enter weekly likes for weeks 1-4");
                        stats.WeeklyLikes = new double[4];
                        for (int i = 0; i < 4; i++)
                        {
                            stats.WeeklyLikes[i] = int.Parse(Console.ReadLine());
                        }
                        RegisterCreator(stats);
                        Console.WriteLine("Creator registered successfully\n");
                        break;
                    case 2:
                        Console.WriteLine("Enter the Like Threshold : ");
                        int threshold = int.Parse(Console.ReadLine());
                        var result = GetTopPostCounts(EngagementBoard, threshold);
                        if (result.Count == 0)
                        {
                            Console.WriteLine("No top-performing posts this week");
                        }
                        else
                        {
                            foreach (var item in result)
                            {
                                Console.WriteLine($"{item.Key} - {item.Value}");
                            }
                        }
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.WriteLine("Overall average weekly likes : " + CalculateAverageLikes()+"\n");
                        break;
                    case 4:
                        Console.WriteLine("Logging off — Keep Creating with StreamBuzz!");
                        terminate = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}