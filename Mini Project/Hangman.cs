using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace Hangman
{
    internal class Program
    {
        static bool ValChar(char input)
        {         
            return Regex.IsMatch(input.ToString(), "[a-z]");
        }
        static void Main(string[] args)
        {
            string[] words = { "computer", "keyboard","monitor","developer","programming","algorithm","database", "network", "software", "hardware", "compiler", "variable", "function", "iteration", "condition", "exception", "interface","inheritance","encapsulation", "polymorphism", "framework" };
            Random random = new Random();
            bool found = false;
            int lives = 6;
            int indexOfWord = random.Next(0, words.Length);
            string wordToGuess = words[indexOfWord];
            char[] displayWord = new char[wordToGuess.Length];
            for (int i = 0; i < displayWord.Length; i++)    { displayWord[i] = '_'; }
            Console.WriteLine("Hangman");
            Console.WriteLine("Word : " + string.Join(" ", displayWord));
            Console.WriteLine();
            HashSet<char> existingLet = new HashSet<char>();

            do
            {
                Console.WriteLine("Guessed : ");
                foreach (var item in existingLet)
                {
                    Console.Write($"{char.ToUpper(item)} ");
                }
                Console.WriteLine();
                Console.Write("Guess a letter : ");
                char guess = char.Parse(Console.ReadLine());
                guess = Char.ToLower(guess);
                if (!ValChar(guess))
                {
                    Console.WriteLine("Invalid character entered.");
                    continue;
                }
                if (existingLet.Contains(guess))
                {
                    Console.WriteLine("Already tried. Pick another.");
                    continue;
                }
                existingLet.Add(guess);
                if (wordToGuess.Contains(guess))
                {
                    for (int i = 0; i < wordToGuess.Length; i++)
                    {
                        if (wordToGuess[i] == guess)
                        {
                            displayWord[i] = guess;
                        }
                    }
                    Console.WriteLine("Correct guess");
                }
                else
                {
                    Console.WriteLine("Wrong choice. Character not present.");
                    lives--;
                }
                Console.WriteLine("\nWord : ");
                for (int i = 0; i < displayWord.Length; i++)
                {
                    Console.Write(char.ToUpper(displayWord[i]) + " ");
                }
                Console.WriteLine($"\nLives left: {lives}");
                Console.WriteLine();
                found = !displayWord.Contains('_');
                if (lives == 0)
                {
                    Console.WriteLine("Game over.");
                    Console.ReadLine();
                    break;
                }
            } while(!found);
            if (found) Console.WriteLine("Correct guess : " + wordToGuess);
        }
    }
}
