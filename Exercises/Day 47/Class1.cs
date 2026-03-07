namespace CargoManifestOptimizer
{
    class Item
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public string Category { get; set; }
        public Item(string name, double weight, string category)
        {
            Name = name;
            Weight = weight;
            Category = category;
        }
    }

    class Container
    {
        public string ContainerID { get; set; }
        public List<Item> Items { get; set; }
        public Container(string id, List<Item> items)
        {
            ContainerID = id;
            if (items != null) Items = items;
        }
    }

    internal class Program
    {
        public static List<string> FindHeavyContainers(List<List<Container>> CargoBay, double weightThreshold)
        {
            //var containers = CargoBay.Where(c => c != null).SelectMany(c => c).ToList();
            //var heavyContainers = containers.Where(c => c.Items.Sum(i => i.Weight) > weightThreshold).Select(c => c.ContainerID).ToList();
            return CargoBay.SelectMany(c=>c).Where(c=>c.Items.Sum(i=>i.Weight) >weightThreshold).Select(c=>c.ContainerID).OrderBy(c=>c).ToList();
        }

        public static Dictionary<string, int> GetItemCountsByCategory(List<List<Container>> CargoBay)
        {
            //var containers = CargoBay.Where(c => c != null).SelectMany(c => c).SelectMany(c => c.Items).ToList();
            //var count = containers.GroupBy(c => c.Category).ToDictionary(g => g.Key, g => g.Count());
            //return count;
            return CargoBay.Where(c => c != null).SelectMany(c => c).SelectMany(c => c.Items).GroupBy(c => c.Category).ToDictionary(g => g.Key, g => g.Count());
        }

        public static List<Item> FlattenAndSortShipment(List<List<Container>> CargoBay)
        {
            //var items = CargoBay.Where(c => c != null).SelectMany(c => c).SelectMany(c => c.Items);
            //var uniqueItems = items.GroupBy(c => c.Name).Select(c => c.First());
            //List<Item> sortedItems = uniqueItems.OrderBy(i => i.Category).ThenByDescending(i => i.Weight).ToList();
            //return sortedItems;
            return CargoBay.Where(c => c != null).SelectMany(c => c).SelectMany(c => c.Items).GroupBy(c => c.Name).Select(c => c.First()).OrderBy(i => i.Category).ThenByDescending(i => i.Weight).ToList();
        }
        static void Main(string[] args)
        {
            var cargoBay = new List<List<Container>>
            {
                new List<Container>
                {
                    new Container("C001", new List<Item>
                    {
                        new Item("Laptop", 2.5, "Tech"),
                        new Item("Monitor", 5.0, "Tech"),
                        new Item("Smartphone", 0.5, "Tech")
                    }),
                    new Container("C104", new List<Item>
                    {
                        new Item("Server Rack", 45.0, "Tech"),
                        new Item("Cables", 1.2, "Tech")
                    })
                },

                new List<Container>
                {
                    new Container("C002", new List<Item>
                    {
                        new Item("Apple", 0.2, "Food"),
                        new Item("Banana", 0.2, "Food"),
                        new Item("Milk", 1.0, "Food")
                    }),
                    new Container("C003", new List<Item>
                    {
                        new Item("Table", 15.0, "Furniture"),
                        new Item("Chair", 7.5, "Furniture")
                    })
                },

                new List<Container>
                {
                    new Container("C205", new List<Item>
                    {
                        new Item("Vase", 3.0, "Decor"),
                        new Item("Mirror", 12.0, "Decor")
                    }),
                    new Container("C206", new List<Item>())
                },

                new List<Container>()
            };

            var heavyContainers = FindHeavyContainers(cargoBay, 30);
            Console.WriteLine("Heavy Containers:");
            Console.WriteLine($"    {string.Join(", ", heavyContainers)}");
            Console.WriteLine();

            var categoryCounts = GetItemCountsByCategory(cargoBay);
            Console.WriteLine("Item Count by Category:");
            foreach (var entry in categoryCounts)
            {
                Console.WriteLine($"    {entry.Key,-10} : {entry.Value}");
            }
            Console.WriteLine();

            var finalShipment = FlattenAndSortShipment(cargoBay);
            Console.WriteLine("Final Shipment:");
            Console.WriteLine($"    {"Category",-12}  {"Name",-14}  {"Weight (in kg) "}");
            Console.WriteLine($"    {new string('-', 44)}");
            foreach (var item in finalShipment)
            {
                Console.WriteLine($"    {item.Category,-12}  {item.Name,-19}  {item.Weight}");
            }
        }
    }
}