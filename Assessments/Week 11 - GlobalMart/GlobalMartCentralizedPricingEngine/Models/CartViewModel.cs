namespace GlobalMartCentralizedPricingEngine.Models
{
    public class CartViewModel
    {
        public List<CartInputModel> Items { get; set; } = new List<CartInputModel>();
        public string PromoCode { get; set; } = "";
        public List<CartItem> CalculatedItems { get; set; } = new List<CartItem>();
        public decimal Total { get; set; }
        public string Message { get; set; } = "";
    }
}
