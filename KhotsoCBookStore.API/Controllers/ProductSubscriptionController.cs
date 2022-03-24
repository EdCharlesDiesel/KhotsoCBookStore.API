using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
        readonly IMapper _mapper;
        readonly IProductSubscriptionService _bookSubscriptionRepository;
        readonly IBookService _bookRepository;
        readonly ICustomerService _customerRepository;

        public ProductSubscriptionController(IMapper mapper,IProductSubscriptionService bookSubscriptionRepository, IBookService bookService, ICustomerService customer)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper)); 

            _bookSubscriptionRepository = bookSubscriptionRepository ?? throw new ArgumentNullException(nameof(_bookSubscriptionRepository));
            _bookRepository = bookService ?? throw new ArgumentNullException(nameof(_bookRepository)); 
            _customerRepository = customer ?? throw new ArgumentNullException(nameof(_customerRepository));
        }

        /// <summary>
        /// Get the list of books subscriptions
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>List of book subscriptions</returns>
        [HttpGet("{customerId}")]
        public  Task<IEnumerable<Book>> GetProductSubscriptions(Guid customerId)
        {
           // return  _bookSubscriptionRepository.GetProductSubscriptionId(customerId);
           throw new NotImplementedException();
        }

        /// <summary>
        /// Add a new book subscription
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ToggleProductSubscription/{customerId}/{bookId}")]
        public Task<IEnumerable<Book>> CreateSubscription(Guid customerId, Guid bookId)
        {
            //_bookSubscriptionRepository.ToggleProductSubscriptionItem(customerId, bookId);
            //return await Task.FromResult(GetUserBookSubscription(customerId)).ConfigureAwait(true);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete a book subscription
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>NoContent</returns>
        [Authorize]
        [HttpDelete("{customerId}")]
        public   Task ClearProductSubscription(Guid customerId)
        {
            //return await _bookSubscriptionRepository.ClearProductSubscriptionAsync(customerId);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a list of user book subscriptions
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>List of book subscription</returns>
        private  Task<IEnumerable<Book>> GetUserBookSubscription(Guid customerId)
        {
            // bool user = _customerRepository.CheckIfCustomerExists(customerId);
            // if (user)
            // {
            //     string BookSubscriptionId = _bookSubscriptionRepository.GetProductSubscriptionId(customerId);
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
