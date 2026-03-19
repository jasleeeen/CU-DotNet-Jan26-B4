using CarMgmtMVCApp.Data;
using CarMgmtMVCApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarMgmtMVCApp.Controllers
{
    [Authorize]
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin,Customer,User")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cars.ToListAsync());
        }

        [Authorize(Roles = "Admin,Customer,User")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var car = await _context.Cars.FirstOrDefaultAsync(m => m.Id == id);
            if (car == null) return NotFound();

            return View(car);
        }

        [Authorize(Roles = "Admin,Customer")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Customer")]
        public async Task<IActionResult> Create([Bind("Id,Brand,Model,Year,Price")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var car = await _context.Cars.FindAsync(id);
            if (car == null) return NotFound();

            return View(car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,Model,Year,Price")] Car car)
        {
            if (id != car.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var car = await _context.Cars.FirstOrDefaultAsync(m => m.Id == id);
            if (car == null) return NotFound();

            return View(car);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}