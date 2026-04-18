namespace NorthwindCatalog.Services.DTOs
{
    public class CategorySummaryDTO
    {
        public string CategoryName { get; set; }
        public int ProductCount { get; set; }
        public decimal AvgPrice { get; set; }
        public string MostExpensiveProduct { get; set; }

    }
}
