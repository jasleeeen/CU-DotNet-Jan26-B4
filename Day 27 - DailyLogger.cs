namespace ConsoleAppDay27_01_DailyLogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"..\..\..\journal.txt";

            Console.WriteLine("Daily Reflection Logger");
            Console.Write("Write reflection : ");
            string reflection = Console.ReadLine();
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($"[{DateTime.Now:dd-MM-yyyy}] - {reflection}");
                }
                Console.WriteLine("\nReflection saved to journal");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred: " + ex.Message);
            }
        }
    }
}
