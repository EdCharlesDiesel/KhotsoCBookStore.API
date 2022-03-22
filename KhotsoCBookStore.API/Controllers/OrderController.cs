using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Dtos;
using KhotsoCBookStore.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KhotsoCBookStore.API.Controllers
{
   // [Authorize]
    [Route("api/Order")]
    public class OrderController : Controller
    {
        readonly IOrderService _orderRepository;

        public OrderController(IOrderService orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(_orderRepository));
        }

        /// <summary>
        /// Get the all the orders for user
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet("{customerId}")]
        public  Task<IEnumerable<OrderDto>> GetOrders(Guid customerId)
        {

            //return await _orderRepository.CreateOrderAsync(customerId,orderItems);
            throw new NotImplementedException();
        }
    }
}
