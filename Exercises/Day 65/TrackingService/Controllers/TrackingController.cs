using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TrackingService.Controllers
{
    [ApiController]
    [Route("api/tracking")]
    public class TrackingController : Controller
    {
        [HttpGet("gps")]
        [Authorize(Roles = "Manager")]
        public IActionResult GetGpsData()
        {
            return Ok(new
            {
                TruckId = "TRUCK-101",
                Location = "Chandigarh",
                Status = "Active",
                Latitude = 30.7333,
                Longitude = 76.7794,
                Timestamp = DateTime.Now
            });

        }
    }
}