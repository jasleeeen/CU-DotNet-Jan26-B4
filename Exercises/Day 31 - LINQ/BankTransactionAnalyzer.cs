using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11._2
{
    class Transaction 
    { 
        public int Acc; 
        public double Amount; 
        public string Type; 
    }
    internal class BankTransactionAnalyzer
    {
        static void Main(string[] args)
        {
            var transactions = new List<Transaction>
            {
                new Transaction{Acc=101, Amount=5000, Type="Credit"},
                new Transaction{Acc=101, Amount=2000, Type="Debit"},
                new Transaction{Acc=102, Amount=10000, Type="Debit"}
            };

            Console.WriteLine("Calculate total balance per account");
            var totalBal = transactions.GroupBy(t => t.Acc).Select(t => new
            {
                Account = t.Key,
                TotalBalance = t.Sum(t => t.Amount)
            }); 
            foreach (var item in totalBal)
            {
                Console.WriteLine(item.Account + " " + item.TotalBalance); 
            }

            Console.WriteLine("\nList suspicious accounts with total debit > credit");
            var susAcc = transactions.GroupBy(t => t.Acc).Select(t => new
            {
                Account = t.Key,
                Debit = t.Where(x => x.Type == "Debit").Sum(x => x.Amount),
                Credit = t.Where(x => x.Type == "Credit").Sum(x => x.Amount),
            }).Where(x => x.Debit > x.Credit);
            foreach (var item in susAcc)
            {
                Console.WriteLine(item.Account);
            }

            Console.WriteLine("\nGroup transactions by month");
            Console.WriteLine("Month not given here");

            Console.WriteLine("\nFind highest transaction amount per account");
            var highestTransactionPerAmmount  = transactions.GroupBy(t=>t.Acc).Select(g => g.OrderByDescending(t => t.Amount).First());
            foreach (var item in highestTransactionPerAmmount)
            {
                Console.WriteLine(item.Acc + " " + item.Amount);
            }
        }
    }
}