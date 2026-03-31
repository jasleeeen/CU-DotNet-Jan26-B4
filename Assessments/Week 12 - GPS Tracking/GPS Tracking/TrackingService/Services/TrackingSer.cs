using TrackingService.Model;
namespace TrackingService.Services
{
    public class TrackingSer
    {
        private static double lat = 30.7333;
        private static double lng = 76.7794;
        private static Random rand = new Random();
        public Location GetLocation()
        {
            lat += (rand.NextDouble() - 0.5) * 0.001;
            lng += (rand.NextDouble() - 0.5) * 0.001;
            return new Location
            {
                TruckId = "TRUCK-101",
                Latitude = lat,
                Longitude = lng,
                Timestamp = DateTime.Now
            };
        }
    }
}