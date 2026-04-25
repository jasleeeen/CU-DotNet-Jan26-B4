using FluentValidationDemo.DTOs;

namespace FluentValidationDemo.Services
{
    public class OrderService : IOrderService
    {
        public OrderService()
        {
        }

        public async Task CreateOrder(CreateOrderDTO dto)
        {
            foreach (var productId in dto.ProductIds)
            {
                bool inStock = true;

                if (!inStock)
                    throw new Exception($"Product {productId} is out of stock");
            }

            if (dto.TotalAmount > 50000)
                throw new Exception("Order amount exceeds limit");

            await Task.CompletedTask;
        }
    }
}
