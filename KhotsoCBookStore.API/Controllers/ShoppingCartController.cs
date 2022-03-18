﻿using System.Collections.Generic;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Dtos;
using KhotsoCBookStore.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
namespace KhotsoCBookStore.API.Controllers
{
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
        /// Get the shopping cart for user.
        /// </summary>
        /// <param name="oldUserId"></param>
        /// <param name="newUserId"></param>
        /// <returns>The count of items in shopping cart</returns>
       // [Authorize]
        [HttpGet]
        [Route("SetShoppingCart/{oldUserId}/{newUserId}")]
        public int Get(Guid oldUserId, Guid newUserId)
        {
            _cartService.MergeCart(oldUserId, newUserId);
            return _cartService.GetCartItemCount(newUserId);
        }

        /// <summary>
        /// Get the list of items in the shopping cart
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<List<CartItemDto>> Get(Guid userId)
        {
            // string cartid = _cartService.GetCartId(userId);
            // var id = new Guid(cartid);
            // return await _bookService.GetBooksAvailableInCartAsync(id);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add a single item into the shopping cart. If the item already exists, increase the quantity by one
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        /// <returns>Count of items in the shopping cart</returns>
        [HttpPost]
        [Route("AddToCart/{userId}/{bookId}")]
        public int Post(Guid userId, Guid bookId)
        {
            _cartService.AddBookToCart(userId, bookId);
            return _cartService.GetCartItemCount(userId);
        }

        /// <summary>
        /// Update item in shopping cart
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpPut("{userId}/{bookId}")]
        public int Put(Guid userId, Guid bookId)
        {
            _cartService.DeleteOneCartItem(userId, bookId);
            return _cartService.GetCartItemCount(userId);
        }

        /// <summary>
        /// Delete a single item from the cart. 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpDelete("{userId}/{bookId}")]
        public int Delete(Guid userId, Guid bookId)
        {
            _cartService.RemoveCartItem(userId, bookId);
            return _cartService.GetCartItemCount(userId);
        }

        /// <summary>
        /// Delete user cart.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpDelete("{userId}")]
        public int Delete(Guid userId)
        {
            return _cartService.ClearCart(userId);
        }
    }
}
