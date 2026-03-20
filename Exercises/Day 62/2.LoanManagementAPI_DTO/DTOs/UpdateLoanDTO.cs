namespace LoanManagementAPI.DTOs
{
    public class UpdateLoanDTO
    {
        public string? BorrowerName { get; set; }
        public decimal? Amount { get; set; }
        public int LoanTermMonths { get; set; }
        public bool IsApproved { get; set; }
    }
}
