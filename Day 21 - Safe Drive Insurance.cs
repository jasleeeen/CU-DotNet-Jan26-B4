using System.Xml.Linq;

namespace SafeDrive
{
    class Policy
    {
        public string HolderName { get; set; }
        public decimal Premium { get; set; }
        public int RiskScore { get; set; }
        public DateTime RenewalDate { get; set; }
        public override string ToString()
        {
            return $"Name : {HolderName}, Premium : {Premium}, Risk Score : {RiskScore}, Renewal Date : {RenewalDate:d}";
        }
    }

    class PolicyManager
    {
        Dictionary<string, Policy> policies = new Dictionary<string, Policy>();

        public bool AddPolicy(string policyId, Policy policy)
        {
            if (!policies.ContainsKey(policyId))
            {
                policies.Add(policyId, policy);
                return true;
            }
            return false;
        }

        public void BulkAdjustment()
        {
            foreach (var item in policies)
            {
                if (item.Value.RiskScore > 75) item.Value.Premium = item.Value.Premium * 1.05m;
            }
        }

        public void CleanUp()
        {
            List<string> keysToRemove = new List<string>();
            foreach (var item in policies)
            {
                if (item.Value.RenewalDate < DateTime.Now.AddYears(-3)) keysToRemove.Add(item.Key);
            }
            foreach (var item in keysToRemove) policies.Remove(item);
        }

        public string SecurityCheck(string policyId)
        {
            if (policies.TryGetValue(policyId, out Policy policy)) return policy.ToString();
            return $"{policyId} not found";
        }

        public void DisplayAll()
        {
            foreach (var item in policies)
            {
                Console.WriteLine($"Policy ID : {item.Key}, {item.Value}");
            }
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            PolicyManager manager = new PolicyManager();
            manager.AddPolicy("101", new Policy
            {
                HolderName = "ABC",
                Premium = 10000m,
                RiskScore = 80,
                RenewalDate = new DateTime(2021, 10, 6)
            });

            manager.AddPolicy("102", new Policy
            {
                HolderName = "DEF",
                Premium = 9000m,
                RiskScore = 80,
                RenewalDate = new DateTime(2025, 6, 16)
            });

            manager.AddPolicy("103", new Policy
            {
                HolderName = "GHI",
                Premium = 5000m,
                RiskScore = 50,
                RenewalDate = new DateTime(2024, 6, 16)
            });

            manager.DisplayAll();
            Console.WriteLine();
            manager.BulkAdjustment();
            manager.CleanUp();
            Console.WriteLine("After Adjustment & Cleanup:");
            manager.DisplayAll();
            Console.WriteLine();
            Console.WriteLine(manager.SecurityCheck("101"));
            Console.WriteLine(manager.SecurityCheck("102"));
        }
    }
}
