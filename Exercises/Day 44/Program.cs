using System.Text;

namespace SAASArch
{
    abstract class Subscriber
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }
        public abstract decimal CalculateMonthlyBill();
        public override bool Equals(object obj)
        {
            Subscriber other = (Subscriber)obj;
            if (other == null)
            {
                return false;
            }
            if (this.ID == other.ID)
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
        public int CompareTo(Subscriber other)
        {
            if (other == null) return 1;
            int dateComparison = this.JoinDate.CompareTo(other.JoinDate);
            if (dateComparison != 0)
                return dateComparison;
            return string.Compare(this.Name, other.Name);
        }
    }

    class BusinessSubscriber : Subscriber
    {
        public decimal FixedRate { get; set; }
        public decimal TaxRate { get; set; }

        public override decimal CalculateMonthlyBill()
        {
            return FixedRate * (1 + TaxRate);
        }
    }

    class ConsumerSubscriber : Subscriber
    {
        public int DataUsageGB { get; set; }
        public decimal PricePerGB { get; set; }
        public override decimal CalculateMonthlyBill()
        {
            return DataUsageGB * PricePerGB;
        }
    }

    class ReportGenerator
    {
        public static void PrintRevenueReport(IEnumerable<Subscriber> subscribers)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{"Name",-20} {"Type",-20} {"Join Date",-20} {"Monthly Bill", -20}");
            foreach (var sub in subscribers)
            {
                sb.AppendLine($"{sub.Name,-20} {sub.GetType().Name,-20} {sub.JoinDate,-20:dd-MM-yyyy} {sub.CalculateMonthlyBill(),-20:C}");
            }
            Console.WriteLine(sb.ToString());
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Dictionary<string, Subscriber> dict = new Dictionary<string, Subscriber>();
            var sub1 = new BusinessSubscriber
            {
                ID = Guid.NewGuid(),
                Name = "ABC",
                JoinDate = new DateTime(2026, 2, 28),
                FixedRate = 100m,
                TaxRate = 0.10m
            };
            var sub2 = new ConsumerSubscriber
            {
                ID = Guid.NewGuid(),
                Name = "DEF",
                JoinDate = new DateTime(2025, 2, 28),
                DataUsageGB = 50,
                PricePerGB = 20m
            };
            var sub3 = new BusinessSubscriber
            {
                ID = Guid.NewGuid(),
                Name = "GHI",
                JoinDate = new DateTime(2024, 2, 28),
                FixedRate = 15000m,
                TaxRate = 0.20m
            };
            var sub4 = new ConsumerSubscriber
            {
                ID = Guid.NewGuid(),
                Name = "JKL",
                JoinDate = new DateTime(2023, 2, 28),
                DataUsageGB = 120,
                PricePerGB = 15m
            };
            var sub5 = new ConsumerSubscriber
            {
                ID = Guid.NewGuid(),
                Name = "MNO",
                JoinDate = new DateTime(2022, 2, 28),
                DataUsageGB = 80,
                PricePerGB = 18m
            };

            dict.Add("ABC@email.com", sub1);
            dict.Add("DEF@email.com", sub2);
            dict.Add("GHI@email.com", sub3);
            dict.Add("JKL@email.com", sub4);
            dict.Add("MNO@email.com", sub5);
            var sortedSubscribers = dict.OrderByDescending(x => x.Value.CalculateMonthlyBill()).Select(x => x.Value).ToList();
            ReportGenerator.PrintRevenueReport(sortedSubscribers);
        }
    }
}
