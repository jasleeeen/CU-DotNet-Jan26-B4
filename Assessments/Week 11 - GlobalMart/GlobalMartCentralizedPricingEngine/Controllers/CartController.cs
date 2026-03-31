using GlobalMartCentralizedPricingEngine.Models;
using GlobalMartCentralizedPricingEngine.Repositories;
using GlobalMartCentralizedPricingEngine.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlobalMartCentralizedPricingEngine.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IPricingService _pricingService;

        public CartController(IProductRepository productRepository, IPricingService pricingService)
        {
            _productRepository = productRepository;
            _pricingService = pricingService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var vm = new CartViewModel
            {
                Items = new List<CartInputModel>
                {
                    new CartInputModel(),
                    new CartInputModel(),
                    new CartInputModel(),
                }
            };
            ViewBag.Products = _productRepository.GetAll().ToList();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(CartViewModel vm)
        {
            var filledItems = vm.Items
                .Where(i => !string.IsNullOrWhiteSpace(i.ProductName) && i.Quantity > 0)
                .ToList();

            vm.CalculatedItems = filledItems.Select(i => new CartItem
            {
                ProductName = i.ProductName,
                BasePrice = i.BasePrice,
                Quantity = i.Quantity,
                FinalUnitPrice = _pricingService.CalculatePrice(i.BasePrice, vm.PromoCode)
            }).ToList();

            vm.Total = vm.CalculatedItems.Sum(i => i.LineTotal);

            string upper = (vm.PromoCode ?? "").ToUpper().Trim();
            if (upper == "WINTER25")
                vm.Message = "15% discount applied!";
            else if (upper == "FREESHIP")
                vm.Message = "$5.00 shipping discount applied!";
            else if (upper == "")
                vm.Message = "";
            else
                vm.Message = $"'{vm.PromoCode}' is not a valid promo code.";
            ViewBag.Products = _productRepository.GetAll().ToList();
            return View(vm);
        }
    }
}
