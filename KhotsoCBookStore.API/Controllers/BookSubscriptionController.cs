using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Authentication;
using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace KhotsoCBookStore.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BookSubscriptionController : Controller
    {
        readonly IBookSubscriptionService _bookSubscriptionService;
        readonly IBookService _bookService;
        readonly IUserService _userService;

        public BookSubscriptionController(IBookSubscriptionService bookSubscriptionService, IBookService bookService, IUserService userService)
        {

            _bookSubscriptionService = bookSubscriptionService;
            _bookService = bookService;
            _userService = userService;

        }

        /// <summary>
        /// Get the list of books subscriptions
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List of book subscriptions</returns>

        [HttpGet("{userId}")]
        public async Task<List<Book>> Get(int userId)
        {
            return await Task.FromResult(GetUserBookSubscription(userId)).ConfigureAwait(true);
        }

        /// <summary>
        /// Add a new book subscription
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ToggleBookSubscription/{userId}/{bookId}")]
        public async Task<List<Book>> Post(int userId, int bookId)
        {
            _bookSubscriptionService.ToggleBookSubscriptionItem(userId, bookId);
            return await Task.FromResult(GetUserBookSubscription(userId)).ConfigureAwait(true);
        }

        /// <summary>
        /// Clear the BookSubscription
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("{userId}")]
        public int Delete(int userId)
        {
            return _bookSubscriptionService.ClearBookSubscription(userId);
        }

        List<Book> GetUserBookSubscription(int userId)
        {
            bool user = _userService.isUserExists(userId);
            if (user)
            {
                string BookSubscriptionId = _bookSubscriptionService.GetBookSubscriptionId(userId);
                return _bookService.GetBooksAvailableInBookSubscription(BookSubscriptionId);
            }
            else
            {
                return new List<Book>();
            }

        }
    }
}
