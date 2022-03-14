using KhotsoCBookStore.API.Models;
using KhotsoCBookStore.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
namespace KhotsoCBookStore.API.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    public class CheckOutController : Controller
    {
        readonly IOrderService _orderService;
        readonly ICartService _cartService;

        public CheckOutController(IOrderService orderService, ICartService cartService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(_orderService));
            _cartService = cartService ?? throw new ArgumentNullException(nameof(_cartService));
        }

        /// <summary>
        /// Add user checkout item(s)
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="checkedOutItems"></param>
        /// <returns></returns>
        [HttpPost("{userId}")]
        public int Post(int userId, [FromBody] OrdersModel checkedOutItems)
        {
            _orderService.CreateOrder(userId, checkedOutItems);
            return _cartService.ClearCart(userId);
        }
    }
}
