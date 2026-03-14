using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinTrackPro.Data;
using FinTrackPro.Models;

//this one manages transactions

namespace FinTrackPro.Controllers
{
    public class AccountController : Controller
    {
        private readonly FinTrackProContext _context;

        public AccountController(FinTrackProContext context)
        {
            _context = context;
        }

        // GET: Account
        public async Task<IActionResult> Index()
        {
            var transactions = _context.Transaction.ToList();
            return View(transactions);
        }

        // GET: Account/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var transaction = await _context.Transaction
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (transaction == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(transaction);
        //}

        // GET: Account/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Amount,Category,Date,AccountID")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Transaction added";
                return RedirectToAction(nameof(Index));
            }
            return View(transaction);
        }

        // GET: Account/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var transaction = await _context.Transaction.FindAsync(id);
        //    if (transaction == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(transaction);
        //}

        // POST: Account/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Amount,Category,Date")] Transaction transaction)
        //{
        //    if (id != transaction.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(transaction);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!TransactionExists(transaction.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(transaction);
        //}

        //// GET: Account/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var transaction = await _context.Transaction
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (transaction == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(transaction);
        //}

        //// POST: Account/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var transaction = await _context.Transaction.FindAsync(id);
        //    if (transaction != null)
        //    {
        //        _context.Transaction.Remove(transaction);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool TransactionExists(int id)
        //{
        //    return _context.Transaction.Any(e => e.Id == id);
        //}
    }
}
