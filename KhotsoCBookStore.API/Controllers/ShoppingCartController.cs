using System.Collections.Generic;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Dtos;
using KhotsoCBookStore.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
namespace KhotsoCBookStore.API.Controllers
{
    [Produces("application/json")]
    [Route("api/ShoppingCart")]
    public class ShoppingCartController : Controller
    {
        readonly ICartService _cartService;
        readonly IBookService _bookService;

        public ShoppingCartController(ICartService cartService, IBookService bookService)
        {
            _cartService = cartService ?? throw new ArgumentNullException(nameof(_cartService));
            _bookService = bookService ?? throw new ArgumentNullException(nameof(_bookService));
        }

        /// <summary>
        /// Get supported resource actions
        /// </summary>
        /// <returns>API actions allowed</returns>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the list of all requests allowed on this end-point</response>
        [HttpOptions]
        public IActionResult GetAuthorsAPIOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,DELETE,PUT,PATCH");
            return Ok();
        }

        /// <summary>
        /// Get the shopping cart for user.
        /// </summary>
        /// <param name="oldUserId"></param>
        /// <param name="newUserId"></param>
        /// <returns>The count of items in shopping cart</returns>
        // [Authorize]
        [HttpGet]
        [Route("SetShoppingCart/{oldUserId}/{newUserId}")]
        public Task<int> GetShoppingCartForCustomer(Guid oldUserId, Guid newUserId)
        {
            _cartService.MergeCart(oldUserId, newUserId);
            return _cartService.GetCartItemCount(newUserId);
        }

        /// <summary>
        /// Get the list of items in the shopping cart
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet("{customerId}")]
        public  Task<List<CartItemDto>> GetItemsInCart(Guid customerId)
        {
            // string cartid = _cartService.GetCartId(customerId);
            // var id = new Guid(cartid);
            // return await _bookService.GetBooksAvailableInCartAsync(id);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add a single item into the shopping cart. If the item already exists, 
        /// increase the quantity by one
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="bookId"></param>
        /// <returns>Count of items in the shopping cart</returns>
        [HttpPost]
        [Route("AddToCart/{customerId}/{bookId}")]
        public Task<int> AddItemToCart(Guid customerId, Guid bookId)
        {
            _cartService.AddBookToCart(customerId, bookId);
            return _cartService.GetCartItemCount(customerId);
        }

        /// <summary>
        /// Update item in shopping cart
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpPut("{customerId}/{bookId}")]
        public Task<int> UpdateCart(Guid customerId, Guid bookId)
        {
            _cartService.DeleteOneCartItem(customerId, bookId);
            return _cartService.GetCartItemCount(customerId);
        }

        /// <summary>
        /// Delete a single item from the cart. 
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpDelete("{customerId}/{bookId}")]
        public Task RemoveItemFromCart(Guid customerId, Guid bookId)
        {
            _cartService.RemoveCartItem(customerId, bookId);
            return _cartService.GetCartItemCount(customerId);
        }

        /// <summary>
        /// Delete user cart.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpDelete("{customerId}")]
        public Task ClearCart(Guid customerId)
        {
            return _cartService.ClearCart(customerId);
        }
    }
}
