using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11._2
{
    class CartItem 
    { 
        public string Name; 
        public string Category; 
        public double Price; 
        public int Qty; 
    }
    internal class ECommerceCartProcessing
    {
        static void Main(string[] args)
        {
            var cart = new List<CartItem>
            {
                new CartItem{Name="TV", Category="Electronics", Price=30000, Qty=1},
                new CartItem{Name="Sofa", Category="Furniture", Price=15000, Qty=1}
            };

            Console.WriteLine("Calculate total cart value");
            var totalCartValue = cart.Sum(c => c.Price * c.Qty);
            Console.WriteLine(totalCartValue);

            Console.WriteLine("\nGroup by Category and total category cost");
            var totalCategoryCost = cart.GroupBy(c => c.Category).Select(c => new
            {
                Category = c.Key,
                TotalCost = c.Sum(x => x.Price * x.Qty)
            });
            foreach (var item in totalCategoryCost)
            {
                Console.WriteLine(item.Category + " " + item.TotalCost);
            }

            Console.WriteLine("\nApply 10% discount for Electronics category");
            var discountOnElec = cart.Where(c => c.Category == "Electronics").Select(c => new
            {
                c.Name,
                DiscPrice = c.Price * 0.9
            });
            foreach (var item in discountOnElec)
            {
                Console.WriteLine(item.Name + " " + item.DiscPrice);
            }

            Console.WriteLine("\nReturn cart summary DTO objects");
            var summary = cart.Select(c=> new
            {
                c.Name, c.Category, c.Price, c.Qty
            });
            foreach (var item in summary)
            {
                Console.WriteLine($"Name: {item.Name} \tCategory: {item.Category} \tPrice: {item.Price} \tQuantity: {item.Qty}");
            }

        }
    }
}
