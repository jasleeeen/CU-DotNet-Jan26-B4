using GlobalMartCentralizedPricingEngine.Models;

namespace GlobalMartCentralizedPricingEngine.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
    }
}
