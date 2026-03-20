namespace LoanManagementAPI.DTOs
{
    public class ReadLoanDTO
    {
        public int Id { get; set; }
        public string? BorrowerName { get; set; }
        public decimal? Amount { get; set; }
        public int LoanTermMonths { get; set; }
        public bool IsApproved { get; set; }
    }
}
