using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using KhotsoCBookStore.API.Dtos;
using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace KhotsoCBookStore.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProductSubscriptionController : Controller
    {
        readonly IMapper _mapper;
        readonly IProductSubscriptionService _productSubscriptionRepository;
        readonly IBookService _bookRepository;
        readonly ICustomerService _customerRepository;

        public ProductSubscriptionController(IMapper mapper,IProductSubscriptionService bookSubscriptionRepository, IBookService bookService, ICustomerService customer)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper)); 
            _productSubscriptionRepository = bookSubscriptionRepository ?? throw new ArgumentNullException(nameof(_productSubscriptionRepository));
            _bookRepository = bookService ?? throw new ArgumentNullException(nameof(_bookRepository)); 
            _customerRepository = customer ?? throw new ArgumentNullException(nameof(_customerRepository));
        }

        /// <summary>
        /// Get supported resource actions
        /// </summary>
        /// <returns>API actions allowed</returns>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the list of all requests allowed on this end-point</response>
        [HttpOptions]
        public IActionResult GetProductSubscriptionAPIOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,DELETE");
            return Ok();
        }

        // /// <summary>
        // /// Get the list of product subscriptions
        // /// </summary>
        // /// <returns>List of book subscriptions</returns>
        // [HttpGet("{customerId}")]
        // public   Task<IEnumerable<BookDto>> GetProductSubscriptions()
        // {
        //     throw new NotImplementedException();
        //    // return  await _productSubscriptionRepository.GetProductSubscription();               
        // }

        // /// <summary>
        // /// Get the single book subscription by Id
        // /// </summary>
        // /// <returns>List of book subscriptions</returns>
        // [HttpGet("{customerId}", Name = "GetProductSubscription")]
        // public  Task<ActionResult<BookDto>> GetProductSubscriptionById(Guid customerId) 
        // { 
        //     throw new NotImplementedException();
        //     //await _productSubscriptionRepository.GetProductSubscriptionById(customerId);
        // }
        // /// <summary>
        // /// Get a list of customer book subscriptions
        // /// </summary>
        // /// <param name="customerId"></param>
        // /// <returns>List of book subscription</returns>
        // private   Task<IEnumerable<BookDto>> GetUserBookSubscription(Guid customerId)
        // {
        //     throw new NotImplementedException();
        //     // var customer = _customerRepository.CheckIfCustomerExists(customerId);
        //     // if (customer!= null)
        //     // {
        //     //     string BookSubscriptionId = await _productSubscriptionRepository.GetProductSubscriptionId(customerId);
        //     //     var Id = new Guid(BookSubscriptionId);
        //     //     return await _bookRepository.GetBooksAvailableInBookSubscription(Id);
        //     // }
            
        //     // return new List<Book>();            
        // }

        /// <summary>
        /// Add a new book subscription
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpPost()]
        [Route("ToggleProductSubscription/{customerId}/{bookId}")]
        public async Task<CreatedAtRouteResult> ToggleProductSubscription(Guid customerId, Guid bookId)
        {
            var productSubscription = new ProductSubscriptionForCreateDto
            {
                CustomerId = customerId,
                DateOfSubscription= DateTime.Now,
            
            };
            var productSubscriptionToCreate = _mapper.Map<Entities.ProductSubscription>(productSubscription);
            await _productSubscriptionRepository.CreateProductSubscriptionAsync(productSubscriptionToCreate);
            await _productSubscriptionRepository.SaveChangesAsync();

            var productSubscriptionToReturn = _mapper.Map<ProductSubscription>(productSubscriptionToCreate);

            return CreatedAtRoute("GetProductSubscription",
                new { productSubscriptionId = productSubscriptionToReturn.ProductSubscriptionId },
                productSubscriptionToReturn);                    
        }

        /// <summary>
        /// Delete a product subscription
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>NoContent</returns>
        [HttpDelete("{customerId}")]
        public  async Task<int> ClearProductSubscription(Guid customerId)
        {
            return await _productSubscriptionRepository.ClearProductSubscriptionAsync(customerId);        
        }      
    }
}
