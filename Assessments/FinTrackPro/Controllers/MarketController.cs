using Microsoft.AspNetCore.Mvc;

namespace FinTrackPro.Controllers
{
    public class MarketController : Controller
    {
        public IActionResult Summary()
        {
            ViewBag.MarketStatus = "Open";
            ViewData["TopGainer"] = "ABC";
            ViewData["Volume"] = 10000000L;
            return View();
        }

        [HttpGet("Analyze/{ticker}/{days:int?}")]

        public IActionResult DataPassing(string ticker, int? days)
        {
            if (days == null) days = 30;
            ViewBag.Ticker = ticker;
            ViewBag.Days = days;
            return View();
        }
    }
}