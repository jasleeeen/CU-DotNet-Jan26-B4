using FinTrackPro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinTrackPro.Controllers
{
    public class PortfolioController : Controller
    {
        private static List<Asset> assets = new List<Asset>()
        {
            new Asset {ID = 1, Name = "ABC", Amount = 10000},
            new Asset {ID = 2, Name = "DEF", Amount = 15000},
            new Asset {ID = 3, Name = "GHI", Amount = 12000},
            new Asset {ID = 4, Name = "JKL", Amount = 8000},
            new Asset {ID = 5, Name = "MNO", Amount = 5000}

        };
        // GET: PortfolioController
        public ActionResult Index()
        {
            ViewData["Total"] = assets.Sum(x => x.Amount);
            return View(assets);
        }

        // GET: PortfolioController/Details/5
        [Route("Asset/Info/{id:int}")]
        public ActionResult Details(int id)
        {
            var asset = assets.FirstOrDefault(x => x.ID == id);
            return View(asset);
        }

        // GET: PortfolioController/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: PortfolioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Asset asset)
        {
            if (ModelState.IsValid)
            {
                asset.ID = assets.Count + 1;
                assets.Add(asset);
                return RedirectToAction("Index");
            }
            return View(asset);
        }

        // GET: PortfolioController/Edit/5
        public ActionResult Edit(int id)
        {
            var asset = assets.FirstOrDefault(x=>x.ID == id);
            if (asset == null) return NotFound();
            return View(asset);
        }

        // POST: PortfolioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Asset asset)
        {
            if (ModelState.IsValid)
            {
                var exist = assets.FirstOrDefault(x => x.ID == asset.ID);
                if (exist != null)
                {
                    exist.Name = asset.Name;
                    exist.Amount = asset.Amount;
                }
                return RedirectToAction("Index");
            }
            return View(asset);
        }

        // GET: PortfolioController/Delete/5
        public ActionResult Delete(int id)
        {
            var asset = assets.FirstOrDefault(x => x.ID == id);
            if (asset == null) return NotFound();
            return View(asset);
        }

        // POST: PortfolioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult Delete2(int id)
        {
            var asset = assets.FirstOrDefault(x => x.ID == id);
            if(asset!=null)
            {
                assets.Remove(asset);
                TempData["Message"] = "Asset deleted";
            }
            return RedirectToAction("Index");
        }
    }
}
