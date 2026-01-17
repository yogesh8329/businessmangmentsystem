using BMS.Core.DTOs;
using BMS.Core.Entities;
using BMS.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // POST: api/order
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            var createdOrder = await _orderRepository.CreateAsync(order);
            return Ok(createdOrder);
        }

        // GET: api/order
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllAsync();
            return Ok(orders);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, UpdateOrderDto dto)
        {
            var order = await _orderRepository.UpdateAsync(id, dto.TotalAmount);
            if (order == null) return NotFound();

            return Ok(order);
        }
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateOrderStatus(int id, UpdateOrderStatusDto dto)
        {
            var order = await _orderRepository.UpdateStatusAsync(id, dto.Status);
            if (order == null) return NotFound();

            return Ok(order);
        }

    }
}
