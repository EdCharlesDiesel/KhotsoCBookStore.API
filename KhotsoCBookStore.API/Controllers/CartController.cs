using System.Collections.Generic;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Dtos;
using KhotsoCBookStore.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;

namespace KhotsoCBookStore.API.Controllers
{
    [Produces("application/json")]
    [Route("api/ShoppingCart")]
    public class CartController : Controller
    {
        readonly ICartService _cartRepository;
        readonly IBookService _bookService;
        readonly IMapper _mapper;

        public CartController(ICartService cartService, IBookService bookService, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
            _cartRepository = cartService ?? throw new ArgumentNullException(nameof(_cartRepository));
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

        [HttpPost()]
        [Route("AddToCart/{customerId}/{bookId}")]
        public  async Task AddItemToCart(Guid customerId, Guid bookId)
        {
            await _cartRepository.AddBookToCartAsync(customerId, bookId);
            await _cartRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Get the list of items in the shopping cart
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet("{customerId}")]
        public async  Task<List<CartItemDto>> GetItemsInCart(Guid customerId)
        {
            string cartid = await  _cartRepository.GetCartIdAsync(customerId);
            var id = new Guid(cartid);
            return (List<CartItemDto>)await _bookService.GetBooksAvailableInCartAsync(id);            
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
            _cartRepository.MergeCart(oldUserId, newUserId);
            return _cartRepository.GetCartItemCount(newUserId);
        }        

        /// <summary>
        /// Add a single item into the shopping cart. If the item already exists, 
        /// increase the quantity by one
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="bookId"></param>
        /// <returns>Count of items in the shopping cart</returns>
        // [HttpPost]
        // [Route("AddToCart/{customerId}/{bookId}")]
        // public  async Task<int> AddItemToCart(Guid customerId, Guid bookId)
        // {
        //     await _cartRepository.CreateCartAsync(customerId);
        //     await _cartRepository.AddBookToCart(customerId, bookId);
        //     return await _cartRepository.GetCartItemCount(customerId);
        // }

        

        /// <summary>
        /// Update item in shopping cart
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpPut("{customerId}/{bookId}")]
        public Task<int> UpdateCart(Guid customerId, Guid bookId)
        {
            // _cartRepository.DeleteCartItem(customerId, bookId);
            // return _cartRepository.GetCartItemCount(customerId);
            throw new NotImplementedException();
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
            _cartRepository.RemoveCartItem(customerId, bookId);
            return _cartRepository.GetCartItemCount(customerId);
        }

        /// <summary>
        /// Delete user cart.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpDelete("{customerId}")]
        public Task ClearCart(Guid customerId)
        {
            return _cartRepository.ClearCart(customerId);
        }
    }
}
