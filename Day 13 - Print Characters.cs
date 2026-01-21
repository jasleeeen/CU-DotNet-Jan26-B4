using System;

namespace ConsoleAppDashes
{
    internal class Program
    {
        static void Main()
        {
            DrawLine();
            DrawLine('+');
            DrawLine('$', 60);
        }
        static void DrawLine(char symbol = '-', int? number = null)
        {
            if (number != null)
            {
                Console.WriteLine(number);
            }

            for (int i = 0; i < 40; i++)
            {
                Console.Write(symbol);
            }
            Console.WriteLine();
        }
    }
}