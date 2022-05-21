// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using AutoMapper;
// using KhotsoCBookStore.API.Entities;
// using KhotsoCBookStore.API.Services;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;

// namespace KhotsoCBookStore.API.Controllers
// {
//     [Produces("application/json")]
//     [Route("api/[controller]")]
//     public class ProductSubscriptionController : Controller
//     {
//         readonly IMapper _mapper;
//         readonly IProductSubscriptionService _productSubscriptionRepository;
//         readonly IBookService _bookRepository;
//         readonly ICustomerService _customerRepository;

//         public ProductSubscriptionController(IMapper mapper,IProductSubscriptionService bookSubscriptionRepository, IBookService bookService, ICustomerService customer)
//         {
//             _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper)); 
//             _productSubscriptionRepository = bookSubscriptionRepository ?? throw new ArgumentNullException(nameof(_productSubscriptionRepository));
//             _bookRepository = bookService ?? throw new ArgumentNullException(nameof(_bookRepository)); 
//             _customerRepository = customer ?? throw new ArgumentNullException(nameof(_customerRepository));
//         }

//         /// <summary>
//         /// Get supported resource actions
//         /// </summary>
//         /// <returns>API actions allowed</returns>
//         /// <returns>An IActionResult</returns>
//         /// <response code="200">Returns the list of all requests allowed on this end-point</response>
//         [HttpOptions]
//         public IActionResult GetProductSubscriptionAPIOptions()
//         {
//             Response.Headers.Add("Allow", "GET,OPTIONS,POST,DELETE");
//             return Ok();
//         }

//         /// <summary>
//         /// Get the list of books subscriptions
//         /// </summary>
//         /// <param name="customerId"></param>
//         /// <returns>List of book subscriptions</returns>
//         [HttpGet("{customerId}")]
//         public  Task<IEnumerable<Book>> GetProductSubscriptions(Guid customerId)
//         {
//            // return   _productSubscriptionRepository.GetProductSubscriptionId(customerId); 
//            throw new NotImplementedException();   
//         }

//         /// <summary>
//         /// Add a new book subscription
//         /// </summary>
//         /// <param name="bookId"></param>
//         /// <param name="customerId"></param>
//         /// <returns></returns>
//         [HttpPost]
//         [Route("ToggleProductSubscription/{customerId}/{bookId}")]
//         public Task<IEnumerable<Book>> CreateSubscription(Guid customerId, Guid bookId)
//         {
//              throw new NotImplementedException();
//             // return await _productSubscriptionRepository.ToggleProductSubscriptionItem(customerId, bookId);           
//         }

//         /// <summary>
//         /// Delete a book subscription
//         /// </summary>
//         /// <param name="customerId"></param>
//         /// <returns>NoContent</returns>
//         [Authorize]
//         [HttpDelete("{customerId}")]
//         public   Task ClearProductSubscription(Guid customerId)
//         {
//              throw new NotImplementedException();
//            // return await _productSubscriptionRepository.ClearProductSubscriptionAsync(customerId);        
//         }

//         /// <summary>
//         /// Get a list of user book subscriptions
//         /// </summary>
//         /// <param name="customerId"></param>
//         /// <returns>List of book subscription</returns>
//         private  Task<IEnumerable<Book>> GetUserBookSubscription(Guid customerId)
//         {
//             // bool user = _customerRepository.CheckIfCustomerExists(customerId);
//             // if (user)
//             // {
//             //     string BookSubscriptionId = _productSubscriptionRepository.GetProductSubscriptionId(customerId);
//             //     var Id = new Guid(BookSubscriptionId);
//             //     return _bookRepository.GetBooksAvailableInBookSubscription(Id);
//             // }
//             // else
//             // {
//             //     return new List<Book>();
//             // }
//              throw new NotImplementedException();
//         }
//     }
// }
