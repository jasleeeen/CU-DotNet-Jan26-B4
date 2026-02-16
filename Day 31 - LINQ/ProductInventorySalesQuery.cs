using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11._2
{
    class Product { 
        public int Id; 
        public string Name; 
        public string Category; 
        public double Price; 
    }
    class Sale { 
        public int ProductId; 
        public int Qty; 
    }
    internal class ProductInventorySalesQuery
    {
        static void Main(string[] args)
        {
            var products = new List<Product>
            {
                new Product{Id=1, Name="Laptop", Category="Electronics", Price=50000},
                new Product{Id=2, Name="Phone", Category="Electronics", Price=20000},
                new Product{Id=3, Name="Table", Category="Furniture", Price=5000}
            };

            var sales = new List<Sale>
            {
                new Sale{ProductId=1, Qty=10},
                new Sale{ProductId=2, Qty=20}
            };

            Console.WriteLine("Join Products with Sales");
            //var joinProductSales = from p in products
            //                       join s in sales 
            //                       on p.Id equals s.ProductId
            //                       select new
            //                       {
            //                           PID = p.Id,
            //                           PName = p.Name,
            //                           PCat = p.Category,
            //                           PPrice = p.Price,
            //                           SQty = s.Qty
            //                       };

            //var joinProductSales = from p in products
            //                       join s in sales
            //                       on p.Id equals s.ProductId
            //                       into SalesProduct
            //                       from item in SalesProduct.DefaultIfEmpty()
            //                       select new
            //                       {
            //                           PID = p.Id,
            //                           PName = p.Name,
            //                           PCat = p.Category,
            //                           PPrice = p.Price,
            //                           SQty = s.Qty
            //                       };

            var joinProductSales = products.Join(sales, o => o.Id, i => i.ProductId,      //inner join
                (p, s) => new { p.Name, s.Qty }
                );
            //var joinProductSales = products.GroupJoin(sales, o => o.Id, i => i.ProductId,
            //    (p, s) => new {
            //        ProductName = p.Name,
            //        TotalQty = s.Sum(x => x.Qty)
            //    });
            foreach (var item in joinProductSales)
            {
                Console.WriteLine($"{item.Name} - {item.Qty}");
            }

            Console.WriteLine("\nCalculate total revenue per product");
            var joinProdSales = products.Join(sales, o => o.Id, i => i.ProductId,
                (p, s) => new { p.Name, s.Qty, p.Price }
                );
            foreach (var item in joinProdSales)
            {
                Console.WriteLine($"{item.Name} - {item.Qty * item.Price}");
            }

            Console.WriteLine("\nGet best-selling product");
            var bestSeller = joinProductSales.OrderByDescending(s=>s.Qty).First();
            Console.WriteLine(bestSeller.Name + " - " + bestSeller.Qty);

            Console.WriteLine("\nList products with zero sales");
            var noSales = products.GroupJoin(sales, o => o.Id, i => i.ProductId,
                (p, s) => new
                {
                    ProductName = p.Name,
                    TotalQty = s.Sum(x => x.Qty)
                }).Where(x => x.TotalQty == 0);
            foreach (var item in noSales)
            {
                Console.WriteLine($"{item.ProductName}");
            }
        }
    }
}
