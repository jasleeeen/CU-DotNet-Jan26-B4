namespace FinTrackPro.Models
{
    public class Transaction
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public int AccountID { get; set; }
        public Account? Account { get; set; } 

    }
}
