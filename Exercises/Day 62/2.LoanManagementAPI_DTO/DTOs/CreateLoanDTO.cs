namespace LoanManagementAPI.DTOs
{
    public class CreateLoanDTO
    {
        public string? BorrowerName { get; set; }
        public decimal? Amount { get; set; }
        public int LoanTermMonths { get; set; }
    }
}
