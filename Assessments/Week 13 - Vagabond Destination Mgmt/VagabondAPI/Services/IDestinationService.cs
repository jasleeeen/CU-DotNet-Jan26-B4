using VagabondAPI.DTO;
using VagabondAPI.Models;

namespace VagabondAPI.Services
{
    public interface IDestinationService
    {
        Task<IEnumerable<Destination>> GetAllAsync();
        Task<Destination> GetByIdAsync(int id);
        Task<Destination> CreateAsync(DestinationDTO dto);
        Task UpdateAsync(int id, DestinationDTO dto);
        Task DeleteAsync(int id);
    }
}
