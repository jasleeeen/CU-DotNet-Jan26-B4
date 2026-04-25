using FluentValidationDemo.Models;

namespace FluentValidationDemo.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> AddAsync(Order order);
        Task<List<Order>> GetAllAsync();
        Task SaveChangesAsync();
    }
}
