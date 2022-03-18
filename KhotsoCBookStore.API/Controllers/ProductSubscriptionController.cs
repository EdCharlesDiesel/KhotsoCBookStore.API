using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KhotsoCBookStore.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProductSubscriptionController : Controller
    {
        readonly IProductSubscriptionService _bookSubscriptionRepository;
        readonly IBookService _bookRepository;
        readonly ICustomerService _customerRepository;

        public ProductSubscriptionController(IProductSubscriptionService bookSubscriptionRepository, IBookService bookService, ICustomerService customer)
        {
            _bookSubscriptionRepository = bookSubscriptionRepository ?? throw new ArgumentNullException(nameof(_bookSubscriptionRepository));
            _bookRepository = bookService ?? throw new ArgumentNullException(nameof(_bookRepository)); 
            _customerRepository = customer ?? throw new ArgumentNullException(nameof(_customerRepository));
        }

        /// <summary>
        /// Get the list of books subscriptions
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List of book subscriptions</returns>

        [HttpGet("{userId}")]
        public async Task<List<Book>> Get(Guid userId)
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
        [Route("ToggleProductSubscription/{userId}/{bookId}")]
        public async Task<List<Book>> Post(Guid userId, Guid bookId)
        {
            _bookSubscriptionRepository.ToggleProductSubscriptionItem(userId, bookId);
            return await Task.FromResult(GetUserBookSubscription(userId)).ConfigureAwait(true);
        }

        /// <summary>
        /// Delete a book subscription
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>0 or 1</returns>
        [Authorize]
        [HttpDelete("{userId}")]
        public int Delete(Guid userId)
        {
            return _bookSubscriptionRepository.ClearProductSubscription(userId);
        }

        /// <summary>
        /// Get a list of user book subscriptions
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List of book subscription</returns>
        private  List<Book> GetUserBookSubscription(Guid userId)
        {
            // bool user = _customerRepository.isUserExists(userId);
            // if (user)
            // {
            //     string BookSubscriptionId = _bookSubscriptionRepository.GetProductSubscriptionId(userId);
            //     var Id = new Guid(BookSubscriptionId);
            //     return _bookRepository.GetBooksAvailableInBookSubscription(Id);
            // }
            // else
            // {
            //     return new List<Book>();
            // }
            throw new NotImplementedException();
        }
    }
}
