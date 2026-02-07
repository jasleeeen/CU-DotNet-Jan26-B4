using System;
using System.Collections.Generic;
using System.IO;

namespace Assessement5FreightTrackingSystem
{
    public class RestrictedDestinationException : Exception
    {
        public string DeniedLocation { get; }

        public RestrictedDestinationException(string location)
            : base($"Shipment denied to restricted destination")
        {
            DeniedLocation = location;
        }
    }
    public class InsecurePackagingException : Exception
    {
        public InsecurePackagingException(string message)
            : base(message)
        {
        }
    }
    public interface ILoggable
    {
        void SaveLog(string message);
    }
    public class LogManager : ILoggable
    {
        string logFile = @"..\..\..\shipment_audit.log";

        public void SaveLog(string message)
        {
            using (StreamWriter writer = new StreamWriter(logFile, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }
    }
    public abstract class Shipment
    {
        public double Weight { get; set; }
        public string Destination { get; set; }
        public string TrackingId { get; set; }

        protected List<string> RestrictedZones = new List<string> { "North Pole", "Unknown Island", "Area 51", "North Korea" };

        public abstract void ProcessShipment();
    }
    public class ExpressShipment : Shipment
    {
        public bool Fragile { get; set; }
        public bool Reinforced { get; set; }

        public override void ProcessShipment()
        {
            if (Weight <= 0)
                throw new ArgumentOutOfRangeException(nameof(Weight), "Weight must be greater than zero.");
            foreach (string zone in RestrictedZones)
            {
                if (zone.ToLower() == Destination.ToLower())
                {
                    throw new RestrictedDestinationException(Destination);
                }
            }
            if (Fragile && !Reinforced)
                throw new InsecurePackagingException("Reinforce fragile shipment");
            Console.WriteLine($"Express shipment {TrackingId} processed.");
        }
    }
    public class HeavyFreight : Shipment
    {
        public bool HeavyLiftPermit { get; set; }
        public override void ProcessShipment()
        {
            if (Weight <= 0)
                throw new ArgumentOutOfRangeException(nameof(Weight), "Weight must be greater than zero.");
            foreach (string zone in RestrictedZones)
            {
                if (zone.ToLower() == Destination.ToLower())
                {
                    throw new RestrictedDestinationException(Destination);
                }
            }
            if (Weight > 1000 && !HeavyLiftPermit)
                throw new Exception("Heavy lift permit required for shipments over 1000kg.");     
            Console.WriteLine($"Heavy freight {TrackingId} processed.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            LogManager log = new LogManager();

            List<Shipment> shipments = new List<Shipment>
            {
                new ExpressShipment
                {
                    TrackingId = "E01",
                    Weight = 10,
                    Destination = "New York",
                    Fragile = true,
                    Reinforced = false
                },
                new HeavyFreight
                {
                    TrackingId = "H02",
                    Weight = 1500,
                    Destination = "Berlin",
                    HeavyLiftPermit = false
                },
                new ExpressShipment
                {
                    TrackingId = "E03",
                    Weight = -5,
                    Destination = "London",
                    Fragile = false,
                    Reinforced = false
                },
                new HeavyFreight
                {
                    TrackingId = "H04",
                    Weight = 800,
                    Destination = "North Pole",
                    HeavyLiftPermit = true
                },
                new ExpressShipment
                {
                    TrackingId = "E05",
                    Weight = 55,
                    Destination = "Washington",
                    Fragile = true,
                    Reinforced = true
                },
                new HeavyFreight
                {
                    TrackingId = "H06",
                    Weight = 800,
                    Destination = "Toronto",
                    HeavyLiftPermit = true
                }
            };
            foreach (Shipment shipment in shipments)
            {
                try
                {
                    shipment.ProcessShipment();
                    log.SaveLog($"Success: Shipment {shipment.TrackingId} processed.");
                }
                catch (RestrictedDestinationException ex)
                {
                    log.SaveLog($"Restricted Destination: {ex.Message},  Location: {ex.DeniedLocation}");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    log.SaveLog($"Invalid weight: {ex.Message}");
                }
                catch (Exception ex)
                {
                    log.SaveLog($"Error: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine($"Processing attempt finished for ID: {shipment.TrackingId}");
                }
            }
            Console.WriteLine("All shipment attempts completed.");
        }
    }
}