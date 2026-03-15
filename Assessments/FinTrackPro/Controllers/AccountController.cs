using Microsoft.AspNetCore.Mvc;
using FinTrackPro.Data;
using FinTrackPro.Models;

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
        public IActionResult Index()
        {
            var transactions = _context.Transaction.ToList();
            return View(transactions);
        }

        // GET: Account/Create
        public IActionResult Create(int accountId)
        {
            ViewBag.AccountId = accountId;
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Description,Amount,Category,Date,AccountId")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                var account = await _context.Account.FindAsync(transaction.AccountID);

                if (account != null)
                {
                    if (transaction.Category == "Expense")
                        account.Balance -= transaction.Amount;
                    else
                        account.Balance += transaction.Amount;
                }

                _context.Add(transaction);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Transaction added";

                return RedirectToAction("Index", "Accounts");
            }

            return View(transaction);
        }
    }
}