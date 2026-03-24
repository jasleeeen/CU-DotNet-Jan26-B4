namespace GlobalMartCentralizedPricingEngine.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public decimal DiscountedPrice { get; set; }
    }
}
