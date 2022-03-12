using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Models;
using KhotsoCBookStore.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KhotsoCBookStore.API.Controllers
{
   // [Authorize]
    [Route("api/Order")]
    public class OrderController : Controller
    {
        readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(_orderService));
        }

        /// <summary>
        /// Get the all the orders for user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        //[HttpGet("{userId}")]
        // public async Task<List<OrdersModel>> Get(int userId)
        // {
        //     return await Task.FromResult(_orderService.GetOrderList(userId)).ConfigureAwait(true);
        // }
    }
}
