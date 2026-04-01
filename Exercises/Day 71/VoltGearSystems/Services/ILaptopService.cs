using VoltGearSystems.Models;

namespace VoltGearSystems.Services
{
    public interface ILaptopService
    {
        Task<List<Laptop>> GetAsync();
        Task CreateAsync(Laptop laptop);
    }
}
