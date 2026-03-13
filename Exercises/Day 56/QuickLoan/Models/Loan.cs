using System.ComponentModel.DataAnnotations;

namespace QuickLoan.Models
{
    public class Loan
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Borrower Name")]
        public string BorrowerName { get; set; }
        public string LenderName { get; set; }
        [Range(0, 500000)]
        public double Amount { get; set; }
        public bool IsSettled { get; set; }
    }
}