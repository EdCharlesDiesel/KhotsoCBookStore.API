using AutoMapper;
using KhotsoCBookStore.API.Dtos;
using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CheckOutController : Controller
    {
        private readonly IMapper _mapper;
        readonly IOrderService _orderRepository;
        readonly ICartService _cartRepository;

        public CheckOutController(IMapper mapper,IOrderService orderService, ICartService cartService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
            _orderRepository = orderService ?? throw new ArgumentNullException(nameof(_orderRepository));
            _cartRepository = cartService ?? throw new ArgumentNullException(nameof(_cartRepository));
        }

        /// <summary>
        /// Get supported resource actions
        /// </summary>
        /// <returns>API actions allowed</returns>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the list of all requests allowed on this end-point</response>
        [HttpOptions]
        public IActionResult GetBookAPIOptions()
        {
            Response.Headers.Add("Allow", "POST,GET");
            return Ok();
        } 

        /// <summary>
        /// Add customer checkout item(s)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="checkedOutItems"></param>
        /// <returns></returns>
        [HttpPost("{CustomerId}")]
        public async Task<ActionResult> CreateOrder(Guid customerId, [FromBody] OrderForCreateDto checkedOutItems)
        {
            var item = _mapper.Map<Order>(checkedOutItems);
            await _orderRepository.CreateOrderAsync(customerId);
            await _orderRepository.SaveChangesAsync();

            var customerToReturn = _mapper.Map<Customer>(item);
            await _cartRepository.ClearCart(customerId);

            return CreatedAtRoute("GetOrderForCustomer",
                new { customerId = customerToReturn.CustomerId },
                customerToReturn);
        }

        /// <summary>
        /// Get a single order for customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>Single Order</returns>
        [HttpGet("{customerId}", Name ="GetOrderForCustomer")]
         public async Task<ActionResult<OrderDto>> GetOrder(Guid customerId)
         {
            if (customerId == new Guid())
            {
               return NotFound();
            }

            var Order = await _orderRepository.GetOrderIdAsync(customerId);
            return Ok(_mapper.Map<OrderDto>(Order));            
         }

        /// <summary>
        /// Get the count of item in the shopping cart
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>The count of items in shopping cart</returns>
        [HttpGet]
         public async  Task<int> GetCartItemCountForCustomer(Guid customerId)
         {
             int cartItemCount =  await _cartRepository.GetCartItemCount(customerId);
             return cartItemCount;
         }
    }
}
