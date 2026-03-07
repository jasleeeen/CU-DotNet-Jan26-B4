using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11._2
{
    class Customer 
    { 
        public int Id; 
        public string Name; 
        public string City; 
    }
    class Order 
    { 
        public int OrderId; 
        public int CustomerId; 
        public double Amount; 
    }

    internal class CustomerOrderAnalysis
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var customers = new List<Customer>
            {
                new Customer{Id=1, Name="Ajay", City="Delhi"},
                new Customer{Id=2, Name="Sunita", City="Mumbai"}
            };

            var orders = new List<Order>
            {
                new Order{OrderId=1, CustomerId=1, Amount=20000},
                new Order{OrderId=2, CustomerId=1, Amount=40000}
            };

            Console.WriteLine("Get total order amount per customer");
            var totalAmt = customers.GroupJoin(orders,
                           c => c.Id,
                           o => o.CustomerId,
                           (c, o) => new
                           {
                               c.Name,
                               TotalAmount = o.Sum(x => x.Amount)
                           });

            foreach (var item in totalAmt)
            {
                Console.WriteLine($"{item.Name} - {item.TotalAmount}");
            }

            Console.WriteLine("\nList customers with no orders");
            var noOrder = customers.GroupJoin(orders,
                           c => c.Id,
                           o => o.CustomerId,
                           (c, o) => new
                           {
                               c.Name,
                               cnt = o.Count()
                           }).Where(x => x.cnt == 0);
            foreach (var item in noOrder)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine($"\n{"Get customers who spent above "} {"50,000":C}");
            var above50k = customers.GroupJoin(orders,
                           c => c.Id,
                           o => o.CustomerId,
                           (c, custOrders) => new
                           {
                               c.Name,
                               TotalAmount = custOrders.Sum(x => x.Amount)
                           }).Where(x => x.TotalAmount > 50000);
            foreach (var item in above50k)
            {
                Console.WriteLine($"{item.Name} - {item.TotalAmount}");
            }

            Console.WriteLine("\nSort customers by total spending");
            var sorted = customers.GroupJoin(orders,
                           c => c.Id,
                           o => o.CustomerId,
                           (c, custOrders) => new
                           {
                               c.Name,
                               TotalAmount = custOrders.Sum(x => x.Amount)
                           })
                .OrderByDescending(x => x.TotalAmount);
            foreach (var item in sorted)
            {
                Console.WriteLine($"{item.Name} - {item.TotalAmount}");
            }
        }

    }
}
