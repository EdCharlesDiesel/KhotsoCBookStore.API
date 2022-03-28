using System.Collections.Generic;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;

namespace KhotsoCBookStore.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class WishListController : Controller
    {
        readonly IWishListService _wishListRepository;
        readonly IBookService _bookRepository;
        readonly ICustomerService _customerRepository;
        public WishListController(IWishListService wishListService,
                                  IBookService bookService,
                                  ICustomerService customer,
                                  IMailService mappermailService)
        {
            
            _wishListRepository = wishListService?? throw new ArgumentNullException(nameof(_wishListRepository));
            _bookRepository = bookService?? throw new ArgumentNullException(nameof(_bookRepository));
            _customerRepository = customer?? throw new ArgumentNullException(nameof(_customerRepository));
        }

        /// <summary>
        /// Get supported resource actions
        /// </summary>
        /// <returns>API actions allowed</returns>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the list of all requests allowed on this end-point</response>
        [HttpOptions]
        public IActionResult GetWishListsAPIOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,DELETE");
            return Ok();
        }

        /// <summary>
        /// Get the list of items in the Wishlist
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>All the items in the Wishlist</returns>
        [HttpGet("{customerId}")]
        public async Task<string> GetWishListsById(Guid customerId)
        {
            return await _wishListRepository.GetWishListId(customerId);
        }

        /// <summary>
        /// Toggle the items in Wishlist. If item doesn't exists, it will be added to the Wishlist else it will be removed.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="bookId"></param>
        /// <returns>All the items in the Wishlist</returns>
        [HttpPost]
        [Route("ToggleWishList/{customerId}/{bookId}")]
        public async Task ToggleWishList(Guid customerId, Guid bookId)
        {
            await _wishListRepository.ToggleWishListItem(customerId, bookId);
        }

        /// <summary>
        /// Clear the Wishlist
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpDelete("{customerId}")]
        public Task ClearWishList(Guid customerId)
        {
            return _wishListRepository.ClearWishList(customerId);
        }

        private async Task<IEnumerable<Book>> GetUserWishList(Guid customerId)
        {
            bool user = await _customerRepository.CustomerIfExistsAsync(customerId);
            if (user)
            {
                string Wishlistid = await _wishListRepository.GetWishListId(customerId);
                var id = new Guid(Wishlistid);
                return await _bookRepository.GetBooksAvailableInBookSubscriptionAsync(id);
            }
            else
            {
                return new List<Book>();
            }
        }
    }
}
