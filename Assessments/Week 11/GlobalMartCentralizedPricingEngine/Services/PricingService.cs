namespace GlobalMartCentralizedPricingEngine.Services
{
    public class PricingService: IPricingService
    {
        public decimal CalculatePrice(decimal basePrice, string promoCode)
        {
            string code = (promoCode ?? string.Empty).ToUpper().Trim();
            if (code == "WINTER25") return basePrice * 0.85m;
            else if (code == "FREESHIP") return (basePrice - 5);
            else return basePrice;
        }
    }
}