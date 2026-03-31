using GlobalMartCentralizedPricingEngine.Repositories;
using GlobalMartCentralizedPricingEngine.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlobalMartCentralizedPricingEngine.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IPricingService _pricingService;
        public ProductsController(IProductRepository productRepository, IPricingService pricingService)
        {
            _productRepository = productRepository;
            _pricingService = pricingService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _productRepository.GetAll().ToList();
            foreach (var product in products)
                product.DiscountedPrice = product.BasePrice;
            ViewBag.PromoCode = "";
            ViewBag.Message = "";
            return View(products);
        }

        [HttpPost]
        public IActionResult Index(string promoCode)
        {
            var products = _productRepository.GetAll().ToList();
            foreach (var product in products)
                product.DiscountedPrice = _pricingService.CalculatePrice(product.BasePrice, promoCode);
            ViewBag.PromoCode = promoCode;
            string upper = (promoCode ?? "").ToUpper().Trim();
            if (upper == "WINTER25")
                ViewBag.Message = "15% discount applied!";
            else if (upper == "FREESHIP")
                ViewBag.Message = "$5.00 shipping discount applied!";
            else if (upper == "")
                ViewBag.Message = "";
            else
                ViewBag.Message = $"'{promoCode}' is not a valid promo code.";
            return View(products);
        }
    }
}