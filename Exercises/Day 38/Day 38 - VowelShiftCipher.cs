using System.Text;

namespace ConsoleApp19._2
{
    internal class VowelShiftCipher
    {
        static string Cipher(string inp)
        {
            StringBuilder sb= new StringBuilder();
            string vowels = "aeiou";
            string input = inp.ToLower();
            foreach (char c in input)
            {
                if (vowels.Contains(c))
                {
                    int index = vowels.IndexOf(c);
                    char nextVowel;
                    if (index == vowels.Length - 1) nextVowel = vowels[0];
                    else nextVowel = vowels[index + 1];
                    sb.Append(nextVowel);
                }
                else
                {
                    char nextChar = (char)(c + 1);
                    if (vowels.Contains(nextChar)) nextChar = (char)(nextChar + 1);
                    if (c == 'z') nextChar = 'a';
                    sb.Append(nextChar);
                }
            }
            return sb.ToString();
        }
        static void Main(string[] args)
        {
            Console.Write("Enter input : ");
            string input = Console.ReadLine();
            Console.WriteLine("Output : " + Cipher(input));
        }
    }
}
