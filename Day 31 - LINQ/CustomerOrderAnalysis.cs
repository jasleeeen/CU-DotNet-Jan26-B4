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
            var totalAmt = customers.Join(orders, o => o.Id, i => i.OrderId,
                (p, s) => new { p.Name, s.Amount }
                );
            foreach (var item in totalAmt)
            {
                Console.WriteLine($"{item.Name} - {item.Amount}");
            }

            Console.WriteLine("\nList customers with no orders");
            var noOrder = customers.GroupJoin(orders, o => o.Id, i => i.OrderId,
                (p, s) => new { p.Name, Amount = s.Amount }
                );
            //var joinProductSales = products.GroupJoin(sales, o => o.Id, i => i.ProductId,
            //    (p, s) => new {
            //        ProductName = p.Name,
            //        TotalQty = s.Sum(x => x.Qty)
            //    });

            //var noSales = products.GroupJoin(sales, o => o.Id, i => i.ProductId,
            //    (p, s) => new
            //    {
            //        ProductName = p.Name,
            //        TotalQty = s.Sum(x => x.Qty)
            //    }).Where(x => x.TotalQty == 0);
            foreach (var item in totalAmt)
            {
                Console.WriteLine($"{item.Name} - {item.Amount}");
            }

            Console.WriteLine("\nGet customers who spent above ₹50,000");
            var totalAmt = customers.Join(orders, o => o.Id, i => i.OrderId,
                (p, s) => new { p.Name, s.Amount }
                );
            foreach (var item in totalAmt)
            {
                Console.WriteLine($"{item.Name} - {item.Amount}");
            }

            Console.WriteLine("\nSort customers by total spending");
            var totalAmt = customers.Join(orders, o => o.Id, i => i.OrderId,
                (p, s) => new { p.Name, s.Amount }
                );
            foreach (var item in totalAmt)
            {
                Console.WriteLine($"{item.Name} - {item.Amount}");
            }

        }
    }
}
