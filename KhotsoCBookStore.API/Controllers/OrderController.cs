using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using KhotsoCBookStore.API.Dtos;
using KhotsoCBookStore.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KhotsoCBookStore.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        readonly IOrderService _orderRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderRepository,IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
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
            Response.Headers.Add("Allow", "GET");
            return Ok();
        }

        /// <summary>
        /// Get the all the orders for user
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested employes.</response>
        [HttpGet("{customerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public  Task<IEnumerable<OrderDto>> GetOrders(Guid customerId)
        {
            // var orders = await _orderRepository.GetAllOrdersForCustomer(customerId);
            // return Ok(_mapper.Map<IEnumerable<OrderDto>>(orders));   
            throw new NotImplementedException();    
        }
    }
}
