namespace SecureTerminal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pin = "";
            Console.Write("Enter 4-digit PIN: ");
            while (pin.Length < 4)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (char.IsLetterOrDigit(key.KeyChar))
                {
                    pin += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (pin.Length > 0)
                    {
                        pin = pin.Substring(0, pin.Length - 1);
                        Console.Write("\b \b");
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("PIN entry complete.");
            Console.WriteLine("Actual PIN: " + pin);
        }
    }
}
