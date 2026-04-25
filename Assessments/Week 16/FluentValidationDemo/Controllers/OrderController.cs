using FluentValidationDemo.DTOs;
using FluentValidationDemo.Responses;
using FluentValidationDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _service.GetOrders();
            return Ok(ApiResponse<List<OrderResponseDTO>>.Ok(orders));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderDTO dto)
        {
            var order = await _service.CreateOrder(dto);
            return Ok(ApiResponse<OrderResponseDTO>.Ok(order, "Order placed successfully"));
        }
    }
}