using GlobalMartCentralizedPricingEngine.Models;

namespace GlobalMartCentralizedPricingEngine.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Clothes", BasePrice = 4000  },
            new Product { Id = 2, Name = "Appliances", BasePrice = 10000 },
            new Product { Id = 3, Name = "Shoes", BasePrice = 5000  },
            new Product { Id = 4, Name = "Electronics", BasePrice = 5000  },
        };

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
    }
}
