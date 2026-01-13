namespace Smart_Access_Control_Log_Processor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Smart Access Control Log Processor");
            Console.WriteLine();
            Console.WriteLine("Enter access attempt in the given format: <GateCode>|<UserInitial>|<AccessLevel>|<IsActive>|<Attempts> (separated by |)");
            string status;
            string input = Console.ReadLine();
            string[] inputs = input.Split("|");
            string gateCode = inputs[0];
            char userInitial = char.Parse(inputs[1]);
            byte accessLevel = byte.Parse(inputs[2]);
            bool isActive = bool.Parse(inputs[3]);
            byte attempts = byte.Parse(inputs[4]);

            if (inputs.Length != 5 || gateCode.Length != 2 || !char.IsLetter(gateCode[0]) || !char.IsDigit(gateCode[1]) || inputs[1].Length != 1 || !char.IsUpper(userInitial) || accessLevel < 1 || accessLevel > 7 || attempts > 200) {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }

            if (!isActive) status = "ACCESS DENIED – INACTIVE USER";
            else if (attempts > 100) status = "ACCESS DENIED – TOO MANY ATTEMPTS";
            else if (accessLevel >= 5) status = "ACCESS GRANTED – HIGH SECURITY";
            else status = "ACCESS GRANTED – STANDARD";
            Console.WriteLine($"{"Gate".PadRight(8)} : {gateCode}");
            Console.WriteLine($"{"User".PadRight(8)} : {userInitial}");
            Console.WriteLine($"{"Level".PadRight(8)} : {accessLevel}");
            Console.WriteLine($"{"Attempts".PadRight(8)} : {attempts}");
            Console.WriteLine($"{"Status".PadRight(8)} : {status}");
        }
    }
}
