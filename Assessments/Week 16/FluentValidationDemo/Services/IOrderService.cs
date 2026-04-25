using FluentValidationDemo.DTOs;

namespace FluentValidationDemo.Services
{
    public interface IOrderService
    {
        Task<OrderResponseDTO> CreateOrder(CreateOrderDTO dto);
        Task<List<OrderResponseDTO>> GetOrders();
    }
}
