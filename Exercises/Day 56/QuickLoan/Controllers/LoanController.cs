using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickLoan.Models;

namespace QuickLoan.Controllers
{
    public class LoanController : Controller
    {
        // GET: LoanController
        private static List<Loan> loans = new List<Loan>()
        {
            new Loan{ ID=1, BorrowerName="ABC", LenderName="ABC Bank", Amount=10000, IsSettled=false},
            new Loan{ ID=2, BorrowerName="BCD", LenderName="XYZ Bank", Amount=250000, IsSettled=true},
            new Loan{ ID=3, BorrowerName="CDE", LenderName="HIJ Bank", Amount=50000, IsSettled=false},
            new Loan{ ID=4, BorrowerName="DEF", LenderName="XYZ Bank", Amount=2500, IsSettled=true},
            new Loan{ ID=5, BorrowerName="EFG", LenderName="ABC Bank", Amount=90000, IsSettled=true},
            new Loan{ ID=6, BorrowerName="FGH", LenderName="XYZ Bank", Amount=100000, IsSettled=false},
            new Loan{ ID=7, BorrowerName="GHI", LenderName="HIJ Bank", Amount=150000, IsSettled=true}
        };
        public ActionResult Index()
        {
            return View(loans);
        }

        // GET: LoanController/Details/5
        public IActionResult Details(int id)
        {
            var loan = loans.FirstOrDefault(x => x.ID == id);

            if (loan == null)
            {
                return NotFound();
            }

            return View(loan);
        }

        // GET: LoanController/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: LoanController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Loan loan)
        {
            if (ModelState.IsValid)
            {
                loan.ID = loans.Count + 1;
                loans.Add(loan);
                return RedirectToAction("Index");
            }
            return View(loan);
        }

        // GET: LoanController/Edit/5
        public ActionResult Edit(int id)
        {
            var loan = loans.FirstOrDefault(x => x.ID == id);
            if (loan == null) return NotFound();
            return View(loan);
        }

        // POST: LoanController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Loan loan)
        {
            if (ModelState.IsValid)
            {
                var existingLoan = loans.FirstOrDefault(x => x.ID == loan.ID);

                if (existingLoan != null)
                {
                    existingLoan.BorrowerName = loan.BorrowerName;
                    existingLoan.LenderName = loan.LenderName;
                    existingLoan.Amount = loan.Amount;
                    existingLoan.IsSettled = loan.IsSettled;
                }
                return RedirectToAction("Index");
            }
            return View(loan);
        }

        //GET: LoanController/Delete/5
        public IActionResult Delete(int id)
        {
            var loan = loans.FirstOrDefault(x => x.ID == id);
            if (loan == null) return NotFound();
            return View(loan);
        }

        // POST: LoanController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var loan = loans.FirstOrDefault(x => x.ID == id);
            if (loan != null) loans.Remove(loan);
            return RedirectToAction("Index");
        }
    }
}