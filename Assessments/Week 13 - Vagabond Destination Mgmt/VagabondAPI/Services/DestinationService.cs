using VagabondAPI.DTO;
using VagabondAPI.GlobalMiddleware;
using VagabondAPI.Models;
using VagabondAPI.Repositories;

namespace VagabondAPI.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly IDestinationRepository _repository;

        public DestinationService(IDestinationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Destination>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Destination> GetByIdAsync(int id)
        {
            var destination = await _repository.GetByIdAsync(id);
            if (destination == null)
            {
                throw new DestinationNotFound(id);
            }
            return destination;
        }

        public async Task<Destination> CreateAsync(DestinationDTO dto)
        {
            var destination = new Destination
            {
                CityName = dto.CityName,
                Country = dto.Country,
                Description = dto.Description,
                Rating = dto.Rating,
                LastVisited = DateTime.Now
            };

            await _repository.AddAsync(destination);
            return destination;
        }

        public async Task UpdateAsync(int id, DestinationDTO dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) throw new DestinationNotFound(id);

            existing.CityName = dto.CityName;
            existing.Country = dto.Country;
            existing.Description = dto.Description;
            existing.Rating = dto.Rating;
            existing.LastVisited = DateTime.Now;

            await _repository.UpdateAsync(existing);
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) throw new DestinationNotFound(id);

            await _repository.DeleteAsync(id);
        }
    }
}
