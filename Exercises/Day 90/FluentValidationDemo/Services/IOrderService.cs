using FluentValidationDemo.DTOs;

namespace FluentValidationDemo.Services
{
    public interface IOrderService
    {
        Task CreateOrder(CreateOrderDTO dto);
    }
}
