namespace Bank_Transaction_Narration_Analyzer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter transaction<TransactionId>#<AccountHolderName>#<TransactionNarration>: ");
            // TX901#Ramesh Kumar#   CASH   deposit   successful  
            string input = Console.ReadLine();
            string[] parts = input.Split('#');
            string transactionId = parts[0];
            string accountHolderName = parts[1];
            string transactionNarration = parts[2];
            transactionNarration = transactionNarration.Trim();
            transactionNarration = transactionNarration.ToLower();
            while (transactionNarration.Contains("  "))
            {
                transactionNarration = transactionNarration.Replace("  ", " ");
            }
            bool status = (transactionNarration.Contains("deposit")) || (transactionNarration.Contains("withdrawl")) || (transactionNarration.Contains("transfer"));
            string standardNarration = "cash deposit successful";
            bool checkEq = transactionNarration.Equals(standardNarration);
            string message = string.Empty;

            if (!status) message = "NON-FINANCIAL TRANSACTION";
            else if (status && checkEq) message = "STANDARD TRANSACTION";
            else if (status && !checkEq) message = "CUSTOM TRANSACTION";

            Console.WriteLine($"{"Transaction ID", -15} : {transactionId}");
            Console.WriteLine($"{"Account Holder", -14}  : {accountHolderName}");
            Console.WriteLine($"{"Narration",-14}  : {transactionNarration}");
            Console.WriteLine($"{"Category",-15} : {message}");

        }
    }
}
