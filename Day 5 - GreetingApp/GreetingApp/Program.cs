using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GreetingLibrary;

namespace GreetingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name: ");
            String name = Console.ReadLine();
            String greetingMessage = GreetingHelper.GetGreeting(name);
            Console.WriteLine(greetingMessage);

        }
    }
}
