using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp31._1
{
    internal class OlaDriver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VehicleNo { get; set; }
        public int Rides { get; set; }
        public List<Ride> rides = new List<Ride>();
        public override string ToString()
        {
            decimal totalFare = 0;
            foreach (var ride in rides)
            {
                totalFare += ride.Fare;
            }
            return $"Driver: {Name}, Vehicle: {VehicleNo}, " +
                   $"Rides: {rides.Count}, Total Fare: {totalFare}";
        }
    }
    internal class Ride
    {
        public int RideId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Fare { get; set; }
        public override string ToString()
        {
            return $"Ride {RideId}: {From} to {To}, Fare: {Fare}";
        }
    }
    internal class OlaDriverClass
    {
        static void Main(string[] args)
        {
            List<OlaDriver> list = new List<OlaDriver>();
            OlaDriver driver1 = new OlaDriver
            {
                Id = 1,
                Name = "ABC",
                VehicleNo = "AB01AB1234"
            };
            OlaDriver driver2 = new OlaDriver
            {
                Id = 1,
                Name = "GHI",
                VehicleNo = "XY01AA1374"
            };
            list.Add(driver1);
            list.Add(driver2);
            driver1.rides.Add(new Ride
            {
                RideId = 101,
                From = "ABC",
                To = "XYZ",
                Fare = 400
            });

            driver1.rides.Add(new Ride
            {
                RideId = 102,
                From = "ECB",
                To = "EUH",
                Fare = 600
            });

            driver2.rides.Add(new Ride
            {
                RideId = 201,
                From = "ABC",
                To = "EDS",
                Fare = 200
            });

            driver2.rides.Add(new Ride
            {
                RideId = 202,
                From = "UHFD",
                To = "KSMXKX",
                Fare = 800
            });

            foreach (var driver in list)
            {
                Console.WriteLine(driver);
                foreach (var ride in driver.rides)
                {
                    Console.WriteLine(ride);
                }
                Console.WriteLine();
            }
        }
    }
}
