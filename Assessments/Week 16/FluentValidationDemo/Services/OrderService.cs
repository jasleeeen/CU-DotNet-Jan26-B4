using AutoMapper;
using FluentValidationDemo.DTOs;
using FluentValidationDemo.Models;
using FluentValidationDemo.Repositories;

namespace FluentValidationDemo.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OrderResponseDTO> CreateOrder(CreateOrderDTO dto)
        {
            if (dto.TotalAmount > 50000)
                throw new InvalidOperationException("Order amount exceeds limit");

            var order = _mapper.Map<Order>(dto);
            order.TotalItems = dto.ProductIds.Count;
            order.CreatedAt = DateTime.UtcNow;

            var created = await _repository.AddAsync(order);
            await _repository.SaveChangesAsync();

            return _mapper.Map<OrderResponseDTO>(created);
        }

        public async Task<List<OrderResponseDTO>> GetOrders()
        {
            var orders = await _repository.GetAllAsync();
            return _mapper.Map<List<OrderResponseDTO>>(orders);
        }
    }
}
