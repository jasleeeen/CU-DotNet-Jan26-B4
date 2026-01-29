using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp29._1
{
    class Flight : IComparable<Flight>
    {
        public string FlightNumber  { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime DepartureTime  { get; set; }
        public int CompareTo(Flight? other)
        {
            if (other == null) return 1;
            return this.Price.CompareTo(other.Price);
        }
        public override string ToString()
        {
            return $"Flight: {FlightNumber}, Price: {Price}, Duration: {Duration}, Departure: {DepartureTime:t}";
        }
    }

    class DurationComparer : IComparer<Flight>
    {
        public int Compare(Flight? x, Flight? y)
        {
            return x.Duration.CompareTo(y.Duration);
        }
    }

    class DepartureComparer : IComparer<Flight>
    {
        public int Compare(Flight? x, Flight? y)
        {
            return x.DepartureTime.CompareTo(y.DepartureTime);
        }
    }

    internal class SkyHigh_Flight_Aggregator
    {
        static void Main(string[] args)
        {
            List<Flight> flights = new List<Flight>()
            {
                new Flight(){ FlightNumber = "ABC105", Price = 25000, Duration = new TimeSpan(5, 30, 0), DepartureTime = new DateTime(2026, 1, 29, 5, 15, 0)},
                new Flight(){ FlightNumber = "DEF101", Price = 15000, Duration = new TimeSpan(2, 30, 0), DepartureTime = new DateTime(2026, 1, 29, 12, 30, 0)},
                new Flight(){ FlightNumber = "ABC110", Price = 20000, Duration = new TimeSpan(9, 00, 0), DepartureTime = new DateTime(2026, 1, 29, 16, 0, 0)},

            };
            flights.Sort();
            Console.WriteLine("Economy View(Sorted by Price)");
            foreach (var item in flights)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("Business Runner View(Sorted by Duration)");
            IComparer<Flight> durationSorter = new DurationComparer();
            flights.Sort(durationSorter);
            foreach (var item in flights)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("Early Bird View(Sorted by Departure Time)");
            flights.Sort(new DepartureComparer());
            foreach (var item in flights)
            {
                Console.WriteLine(item);
            }
        }
    }
}
