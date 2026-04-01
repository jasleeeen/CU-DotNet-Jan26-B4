using Microsoft.AspNetCore.Mvc;
using VoltGearSystems.Models;
using VoltGearSystems.Services;

namespace VoltGearSystems.Controllers
{
    public class LaptopController : Controller
    {
        private readonly ILaptopService _service;

        public LaptopController(ILaptopService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var laptops = await _service.GetAsync();
            return View(laptops);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Laptop laptop)
        {
            if (!ModelState.IsValid)
                return View(laptop);

            await _service.CreateAsync(laptop);

            TempData["Success"] = "Laptop successfully saved!";
            return RedirectToAction("Index");
        }
    }
}
