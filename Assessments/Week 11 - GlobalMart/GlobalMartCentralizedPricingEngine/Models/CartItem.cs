namespace GlobalMartCentralizedPricingEngine.Models
{
    public class CartItem
    {
        public string ProductName { get; set; }
        public decimal BasePrice { get; set; }
        public int Quantity { get; set; }
        public decimal FinalUnitPrice { get; set; }
        public decimal LineTotal => FinalUnitPrice * Quantity;
    }
}
