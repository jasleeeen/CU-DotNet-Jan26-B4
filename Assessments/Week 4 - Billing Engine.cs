using System.Text;
using System.Xml.Linq;

namespace Assessment4Billing_Engine
{
    class Patient
    {
        public string Name { get; set; }
        public decimal BaseFee { get; set; }
        public virtual decimal CalculateFinalBill() 
        {
            return BaseFee;
        }
        public override string ToString()
        {
            return $"Name : {Name}, Base Fee : {BaseFee}, Final Bill : {CalculateFinalBill().ToString("C2")}";
        }
    }

    class Inpatient : Patient
    {
        public int DaysStayed { get; set; }
        public decimal DailyRate { get; set; }
        override public decimal CalculateFinalBill()
        {
            return BaseFee + (DaysStayed * DailyRate);
        }
        public override string ToString()
        {
            return $"{base.ToString()}, Days Stayed : {DaysStayed}, Daily Rate : {DailyRate.ToString("C2")}";
        }
    }

    class Outpatient : Patient
    {
        public decimal ProcedureFee { get; set; }
        override public decimal CalculateFinalBill()
        {
            return BaseFee + ProcedureFee;
        }
        public override string ToString()
        {
            return $"{base.ToString()}, Procedure Fee : {ProcedureFee.ToString("C2")}";
        }
    }

    class EmergencyPatient : Patient
    {
        public int SeverityLevel { get; set; }
        override public decimal CalculateFinalBill()
        {
            if (SeverityLevel < 0 || SeverityLevel > 5) {
                Console.WriteLine("Invalid Severity Level");
                return BaseFee;
            }

            return BaseFee * SeverityLevel;
        }
        public override string ToString()
        {
            return $"{base.ToString()}, Severity Level : {SeverityLevel}";
        }
    }

    class HospitalBilling
    {
        public List<Patient> patients = new List<Patient>();
        public void AddPatient(Patient p)
        {
            patients.Add(p);
            Console.WriteLine($"Patient {p.Name} added.");
        }
        public void GenerateDailyReport()
        {
            Console.WriteLine("Daily report");
            foreach (var item in patients)
            {
                Console.WriteLine(item);
            }
        }
        public decimal CalculateTotalRevenue()
        {
            decimal sum = 0;
            foreach (var item in patients)
            {
                sum += item.CalculateFinalBill();
            }
            return sum;
        }

        public int GetInpatientCount()
        {
            int count=0;
            foreach (var item in patients)
            {
                if (item is Inpatient) count++;
            }
            return count;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("The St. Memorial Billing Engine");
            Console.WriteLine();
            HospitalBilling billing = new HospitalBilling();
            billing.AddPatient(new Inpatient
            {
                Name = "ABC",
                BaseFee = 1000,
                DaysStayed = 3,
                DailyRate = 5000
            });

            billing.AddPatient(new Outpatient
            {
                Name = "DEF",
                BaseFee = 1000,
                ProcedureFee = 25000
            });

            billing.AddPatient(new EmergencyPatient
            {
                Name = "GHI",
                BaseFee = 3000,
                SeverityLevel = 4
            });
            Console.WriteLine();
            billing.GenerateDailyReport();
            Console.WriteLine();
            Console.WriteLine($"Total Revenue : {billing.CalculateTotalRevenue().ToString("C2")}");
            Console.WriteLine($"Number of Inpatients : {billing.GetInpatientCount()}");
        }
    }
}
