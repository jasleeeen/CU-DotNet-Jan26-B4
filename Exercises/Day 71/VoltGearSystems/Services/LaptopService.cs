using MongoDB.Driver;
using VoltGearSystems.Models;
using VoltGearSystems.MongoDBSettings;
using VoltGearSystems.Services;

namespace VoltGearSystems.Services
{
    public class LaptopService : ILaptopService
    {
        private readonly IMongoCollection<Laptop> _collection;
        public LaptopService(IConfiguration config)
        {
            var settings = config.GetSection("MongoDbSettings").Get<MongoDbSettings>();

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<Laptop>(settings.LaptopCollection);
        }

        public async Task<List<Laptop>> GetAsync()
        {
            return await _collection.Find(laptop => true).ToListAsync(); ;
        }

        public async Task CreateAsync(Laptop laptop)
        {
            await _collection.InsertOneAsync(laptop);
        }
    }
}