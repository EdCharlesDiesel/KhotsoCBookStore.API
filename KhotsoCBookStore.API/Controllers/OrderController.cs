using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Dtos;
using KhotsoCBookStore.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KhotsoCBookStore.API.Controllers
{
     [Produces("application/json")]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        readonly IOrderService _orderRepository;

        public OrderController(IOrderService orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(_orderRepository));
        }

        
        /// <summary>
        /// Get supported resource actions
        /// </summary>
        /// <returns>API actions allowed</returns>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the list of all requests allowed on this end-point</response>
        [HttpOptions]
        public IActionResult GetOrderAPIOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,DELETE");
            return Ok();
        }

        /// <summary>
        /// Get the all the orders for user
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet("{customerId}")]
        public  Task<IEnumerable<OrderDto>> GetOrders(Guid customerId)
        {
            return await _orderRepository.CreateOrderAsync(customerId,orderItems);            
        }
    }
}
