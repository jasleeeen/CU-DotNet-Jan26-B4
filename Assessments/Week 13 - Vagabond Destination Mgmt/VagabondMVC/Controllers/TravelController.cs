using Microsoft.AspNetCore.Mvc;
using VagabondMVC.Models;
using VagabondMVC.Services;

namespace VagabondMVC.Controllers
{
    public class TravelController : Controller
    {
        private readonly IDestinationService _service;

        public TravelController(IDestinationService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var destinations = await _service.GetAllAsync();
            return View(destinations);
        }

        public async Task<IActionResult> Details(int id)
        {
            var destination = await _service.GetByIdAsync(id);
            if (destination == null) return NotFound();
            return View(destination);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Destination destination)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(destination);
                TempData["SuccessMessage"] = "Destination created successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(destination);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var destination = await _service.GetByIdAsync(id);
            if (destination == null) return NotFound();
            return View(destination);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Destination destination)
        {
            if (id != destination.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(id, destination);
                TempData["SuccessMessage"] = "Destination updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(destination);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var destination = await _service.GetByIdAsync(id);
            if (destination == null) return NotFound();
            return View(destination);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            TempData["SuccessMessage"] = "Destination deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}