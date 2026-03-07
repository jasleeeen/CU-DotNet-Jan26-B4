using System.Diagnostics.Metrics;
using System.Transactions;

namespace FinancialPortfolioManagement
{
    interface IRiskAssessable
    {
        string GetRiskCategory();
    }

    interface IReportable
    {
        string GenerateReportLine();
    }

    abstract class FinancialInstrument
    {
        public string InstrumentId { get; set; }
        public string Name { get; set; }
        public DateOnly PurchaseDate { get; set; }
        private string _currency;
        private int _units;
        private decimal _purchasePrice;
        private decimal _marketPrice;
        public string Currency
        {
            get { return _currency; }
            set
            {
                if (value.Length != 3 || string.IsNullOrWhiteSpace(value)) throw new InvalidFinancialDataException("Currency must be a 3 letter code");
                _currency = value.ToUpper();
            }
        }
        public int Units
        {
            get { return _units; }
            set
            {
                if (value < 0) throw new InvalidFinancialDataException("Quantity cannot be negative");
                _units = value;
            }
        }
        public decimal PurchasePrice
        {
            get { return _purchasePrice; }
            set
            {
                if (value < 0) throw new InvalidFinancialDataException("Price cannot be negative");
                _purchasePrice = value;
            }
        }
        public decimal MarketPrice
        {
            get { return _marketPrice; }
            set
            {
                if (value < 0) throw new InvalidFinancialDataException("Price cannot be negative");
                _marketPrice = value;
            }
        }

        public abstract decimal CalculateCurrentValue();
        public virtual string GetInstrumentSummary()
        {
            return $"{InstrumentId} | {Name} | {Currency} | {"Units : " + Units} | {"Purchased on " + PurchaseDate}";
        }
        public decimal CalculateInvestment()
        {
            return Units * PurchasePrice;
        }
    }

    class InvalidFinancialDataException : Exception
    {
        public InvalidFinancialDataException(string message) : base(message) { }
    }

    class Equity : FinancialInstrument, IRiskAssessable, IReportable
    {
        public override decimal CalculateCurrentValue()
        {
            return Units * MarketPrice;
        }
        public string GenerateReportLine()
        {
            return $"{InstrumentId} | {Name} | Equity | {CalculateCurrentValue():C}";
        }
        public string GetRiskCategory()
        {
            return "High";
        }
    }

    class FixedDeposit : FinancialInstrument
    {
        public override decimal CalculateCurrentValue()
        {
            return Units * MarketPrice;
        }
    }

    class Bond : FinancialInstrument, IRiskAssessable, IReportable
    {
        public override decimal CalculateCurrentValue()
        {
            return Units * MarketPrice;
        }

        public string GenerateReportLine()
        {
            return $"{InstrumentId} | {Name} | Bond | {CalculateCurrentValue():C}";
        }

        public string GetRiskCategory()
        {
            return "Low";
        }
    }

    class MutualFund : FinancialInstrument, IRiskAssessable, IReportable
    {
        public override decimal CalculateCurrentValue()
        {
            return Units * MarketPrice;
        }

        public string GenerateReportLine()
        {
            return $"{InstrumentId} | {Name} | Mutual Fund | {CalculateCurrentValue
                ():C}";
        }

        public string GetRiskCategory()
        {
            return "Medium";
        }
    }

    class Portfolio
    {
        List<FinancialInstrument> instruments = new List<FinancialInstrument>();
        Dictionary<string,FinancialInstrument> dict = new Dictionary<string,FinancialInstrument>();

        public void AddInstrument(FinancialInstrument instrument)
        {
            if (dict.ContainsKey(instrument.InstrumentId))
            {
                Console.WriteLine("Duplicate Instrument ID");
                return;
            }
            instruments.Add(instrument);
            dict[instrument.InstrumentId] = instrument;
        }
        public void RemoveInstrument(string id)
        {
            if (dict.ContainsKey(id))
            {
                instruments.Remove(dict[id]);
                dict.Remove(id);
            }
        }
        public decimal GetTotalPortfolioValue()
        {
            return instruments.Sum(i => i.CalculateCurrentValue());
        }
        public FinancialInstrument GetInstrumentById(string id)
        {
            return dict.ContainsKey(id) ? dict[id] : null;
        }
        public List<FinancialInstrument> GetInstrumentsByRisk(string risk)
        {
            List<FinancialInstrument> result = new List<FinancialInstrument>();
            foreach (var instrument in instruments)
            {
                if (instrument is IRiskAssessable riskInstrument)
                {
                    if (riskInstrument.GetRiskCategory().ToLower() == risk.ToLower())
                    {
                        result.Add(instrument);
                    }
                }
            }
            return result;
        }

        public List<FinancialInstrument> GetAll()
        {
            return instruments.OrderByDescending(i => i.CalculateCurrentValue()).ToList();
        }
    }



    class Transaction
    {
        public int TransactionId { get; set; }
        public string InstrumentId { get; set; }
        public string Type { get; set; }
        public int Units { get; set; }
        public DateOnly Date { get; set; }
    }

    class TransactionProcessor
    {
        public static void ProcessTransactions(Portfolio portfolio, Transaction[] transactionArray)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<Transaction> transactions = transactionArray.ToList();
            foreach (var t in transactions)
            {
                var instrument = portfolio.GetInstrumentById(t.InstrumentId);
                if (instrument == null)
                    continue;
                if (t.Type.Equals("Buy")) instrument.Units += t.Units;
                else if (t.Type.Equals("Sell", StringComparison.OrdinalIgnoreCase))
                {
                    if (t.Units > instrument.Units) throw new Exception("Can not sell more units than owned");
                    instrument.Units -= t.Units;
                }
            }
        }
    }

    class ReportGenerator
    {
        public static void GenerateConsoleReport(Portfolio portfolio)
        {
            var grouped = portfolio.GetAll().GroupBy(i => i.GetType().Name);

            foreach (var group in grouped)
            {
                decimal totalInvestment = group.Sum(i => i.CalculateInvestment());
                decimal currentValue = group.Sum(i => i.CalculateCurrentValue());
                decimal profit = currentValue - totalInvestment;

                Console.WriteLine($"\nInstrument Type: {group.Key}");
                Console.WriteLine($"Total Investment: {totalInvestment:C}");
                Console.WriteLine($"Current Value: {currentValue:C}");
                Console.WriteLine($"Profit/Loss: {profit:C}");
            }

            Console.WriteLine($"\nOverall Portfolio Value: {portfolio.GetTotalPortfolioValue():C}");

            var riskGroups = portfolio.GetAll()
                .OfType<IRiskAssessable>()
                .GroupBy(r => r.GetRiskCategory());

            Console.WriteLine("\nRisk Distribution:");
            foreach (var group in riskGroups)
                Console.WriteLine($"{group.Key}: {group.Count()}");
        }

        public static void GenerateFileReport(Portfolio portfolio)
        {
            string fileName = $"PortfolioReport_{DateTime.Now:yyyyMMdd}.txt";

            try
            {
                using StreamWriter writer = new StreamWriter(fileName);

                writer.WriteLine("===== PORTFOLIO REPORT =====");
                writer.WriteLine($"Generated On: {DateTime.Now}");
                writer.WriteLine();

                foreach (var instrument in portfolio.GetAll())
                {
                    writer.WriteLine(instrument.GetInstrumentSummary());
                }

                writer.WriteLine();
                writer.WriteLine($"Total Portfolio Value: {portfolio.GetTotalPortfolioValue():C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("File Write Error: " + ex.Message);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Portfolio portfolio = new Portfolio();

            Equity eq = new Equity
            {
                InstrumentId = "EQ001",
                Name = "INFY",
                Currency = "INR",
                Units = 100,
                PurchasePrice = 1500,
                MarketPrice = 1650,
                PurchaseDate = DateOnly.FromDateTime(DateTime.Now)
            };

            Bond bond = new Bond
            {
                InstrumentId = "BD001",
                Name = "GovBond",
                Currency = "INR",
                Units = 50,
                PurchasePrice = 1000,
                MarketPrice = 1100,
                PurchaseDate = DateOnly.FromDateTime(DateTime.Now)
            };

            portfolio.AddInstrument(eq);
            portfolio.AddInstrument(bond);

            Transaction[] transactions =
            {
                    new Transaction { TransactionId = 1, InstrumentId = "EQ001", Type = "Buy", Units = 10, Date = DateOnly.FromDateTime(DateTime.Now) },
                    new Transaction { TransactionId = 2, InstrumentId = "BD001", Type = "Sell", Units = 5, Date = DateOnly.FromDateTime(DateTime.Now) }
                };

            TransactionProcessor.ProcessTransactions(portfolio, transactions);

            ReportGenerator.GenerateConsoleReport(portfolio);
            ReportGenerator.GenerateFileReport(portfolio);
        }
    }
}
