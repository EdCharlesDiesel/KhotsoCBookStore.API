using System.Collections.Generic;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
namespace KhotsoCBookStore.API.Controllers
{
    [Route("api/Wishlist")]
    public class WishListController : Controller
    {
        readonly IWishListService _wishListService;
        readonly IBookService _bookService;
        readonly ICustomerService _customer;

        public WishListController(IWishListService wishListService, IBookService bookService, ICustomerService customer)
        {
            _wishListService = wishListService?? throw new ArgumentNullException(nameof(_wishListService));
            _bookService = bookService?? throw new ArgumentNullException(nameof(_bookService));
            _customer = customer?? throw new ArgumentNullException(nameof(_customer));
        }

        /// <summary>
        /// Get the list of items in the Wishlist
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>All the items in the Wishlist</returns>
        [HttpGet("{userId}")]
        public async Task<List<Book>> GetWishListById(Guid userId)
        {
            return await Task.FromResult(GetUserWishlist(userId)).ConfigureAwait(true);
        }

        /// <summary>
        /// Toggle the items in Wishlist. If item doesn't exists, it will be added to the Wishlist else it will be removed.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        /// <returns>All the items in the Wishlist</returns>
       // [Authorize]
        [HttpPost]
        [Route("ToggleWishlist/{userId}/{bookId}")]
        public async Task<List<Book>> Post(Guid userId, Guid bookId)
        {
            _wishListService.ToggleWishlistItem(userId, bookId);
            return await Task.FromResult(GetUserWishlist(userId)).ConfigureAwait(true);
        }

        /// <summary>
        /// Clear the Wishlist
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        ///[Authorize]
        [HttpDelete("{userId}")]
        public int Delete(Guid userId)
        {
            return _wishListService.ClearWishlist(userId);
        }

        List<Book> GetUserWishlist(Guid customerId)
        {
            // bool user = _customer.isUserExists(customerId);
            // if (user)
            // {
            //     string Wishlistid = _wishListService.GetWishlistId(customerId);
            //     var id = new Guid(Wishlistid);
            //     return _bookService.GetBooksAvailableInWishlist(id);
            // }
            // else
            // {
            //     return new List<Book>();
            // }

            throw new ArgumentNullException();
        }
    }
}
