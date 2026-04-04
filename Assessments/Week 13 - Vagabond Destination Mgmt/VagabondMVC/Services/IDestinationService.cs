using VagabondMVC.Models;

namespace VagabondMVC.Services
{
    public interface IDestinationService
    {
        Task<IEnumerable<Destination>> GetAllAsync();
        Task<Destination> GetByIdAsync(int id);
        Task CreateAsync(Destination destination);
        Task UpdateAsync(int id, Destination destination);
        Task DeleteAsync(int id);
    }
}