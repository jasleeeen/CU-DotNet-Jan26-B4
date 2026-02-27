namespace Simple_User_Login_Message_Processor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter input in the given format: <UserName>|<LoginMessage>");
            string input = Console.ReadLine();
            input = input.ToLower();
            string[] parts = input.Split('|', StringSplitOptions.TrimEntries);
            string userName = parts[0];
            string loginMessage = parts[1];

            bool status = loginMessage.Contains("successful");
            string standardMessage = "login successful";
            if (!status)
            {
                Console.WriteLine("LOGIN FAILED");
            }
            if (String.Equals(loginMessage, standardMessage))
            {
                Console.WriteLine("LOGIN SUCCESS");
            }
            if (status && (!String.Equals(loginMessage, standardMessage)))
            {
                Console.WriteLine("LOGIN SUCCESS (CUSTOM MESSAGE)");
            }
        }
    }
}
