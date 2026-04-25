using FluentValidationDemo.Data;
using FluentValidationDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace FluentValidationDemo.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Order> AddAsync(Order order)
        {
            var entry = await _context.Orders.AddAsync(order);
            return entry.Entity;
        }

        public Task<List<Order>> GetAllAsync() => _context.Orders.AsNoTracking().ToListAsync();

        public Task SaveChangesAsync() => _context.SaveChangesAsync();
    }
}
