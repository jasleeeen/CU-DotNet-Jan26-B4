using Microsoft.EntityFrameworkCore;
using VagabondAPI.Data;
using VagabondAPI.Models;

namespace VagabondAPI.Repositories
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly VagabondAPIContext _context;

        public DestinationRepository(VagabondAPIContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Destination destination)
        {
            await _context.Destinations.AddAsync(destination);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var destination = await _context.Destinations.FindAsync(id);
            if (destination != null)
            {
                _context.Destinations.Remove(destination);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Destination>> GetAllAsync()
        {
            return await _context.Destinations.ToListAsync();
        }

        public async Task<Destination?> GetByIdAsync(int id)
        {
            return await _context.Destinations.FindAsync(id);
        }

        public async Task UpdateAsync(Destination destination)
        {
            _context.Destinations.Update(destination);
            await _context.SaveChangesAsync();
        }
    }
}
