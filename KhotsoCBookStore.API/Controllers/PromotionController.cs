using System.Collections.Generic;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using KhotsoCBookStore.API.Dtos;

namespace KhotsoCBookStore.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PromotionsController : Controller
    {
        private readonly IPromotionService _promotionRepository;
        private readonly IBookService _bookService;
        private readonly ICustomerService _customerRepository;
        private IMapper _mapper;

        public PromotionsController(
            IPromotionService promotionRepository, 
            IBookService bookService,
            ICustomerService customerRepository,
            IMapper mapper)
        {
            _mapper = mapper?? throw new ArgumentNullException(nameof(mapper));
            _promotionRepository = promotionRepository?? throw new ArgumentNullException(nameof(_promotionRepository));
            _bookService = bookService?? throw new ArgumentNullException(nameof(_bookService));
            _customerRepository = customerRepository?? throw new ArgumentNullException(nameof(_customerRepository));
        }

        /// <summary>
        /// Get supported resource actions
        /// </summary>
        /// <returns>API actions allowed</returns>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the list of all requests allowed on this end-point</response>
        [HttpOptions]
        public IActionResult GetPromotionAPIOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,DELETE,PUT,PATCH");
            return Ok();
        }

        /// <summary>
        /// Get the list of items in the Promotion
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>All the items in the Promotion</returns>
        [HttpGet("{customerId}")]
        public  Task<IEnumerable<Promotion>> GetPromotion(Guid customerId)
        {
            // return await GetUserPromotion(customerId);
            throw new NotImplementedException();
        }


        /// <summary>
        /// Toggle the items in Promotion. If item doesn't exists, 
        /// it will be added to the Promotion else it will be removed.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="bookId"></param>
        /// <returns>All the items in the Promotion</returns>
        /// [Authorize]
        [HttpPost]
        [Route("TogglePromotion/{customerId}/{bookId}")]
        public  Task<IEnumerable<Book>> CreatePromotion(Guid customerId, Guid bookId)
        {
            // await _promotionRepository.CreatePromotionAsync(customerId);
            // return await GetUserPromotion(customerId);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Clear the Promotion
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        ///[Authorize]
        [HttpDelete("{customerId}")]
        public Task Delete(Guid customerId)
        {
            throw new NotImplementedException();
        }

        private  List<Book> GetPromotion__(Guid customerId)
        {
            // var customer = await _customerRepository.CheckIfCustomerExists(customerId);
            // if (customer)
            // {
            //     string Promotionid = await _promotionRepository.GetPromotionById(customerId);
            //     return _bookService.GetBooksAvailableInPromotion(Promotionid);
            // }
            // else
            // {
            //     return new List<Book>();
            // } 
            throw new NotImplementedException();          
        }

         /// <summary>
        /// Get the list of orders.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetBooksAvailableInPromotion")]
        public Task<IEnumerable<BookDto>> GetBooksAvailableInPromotion()
        {
            // // var categories = _mapper.Map<Category>(CategoryDto);
             //return await _bookRepository.GetBooksAvailableInPromotionAsync

            throw new NotImplementedException();
        }
    }
}
