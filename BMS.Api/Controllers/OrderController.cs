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
    }
}
