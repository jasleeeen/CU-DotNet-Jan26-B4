namespace GlobalMartCentralizedPricingEngine.Services
{
    public interface IPricingService
    {
        decimal CalculatePrice(decimal basePrice, string promoCode);
    }
}
