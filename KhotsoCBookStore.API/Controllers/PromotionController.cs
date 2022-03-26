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
    public class PromotionsController : Controller
    {
        readonly IPromotionService _promotionService;
        readonly IBookService _bookService;
        readonly ICustomerService _customerRepository;

        private IMapper _mapper;

        public PromotionsController(
            IPromotionService promotionService, 
        IBookService bookService,
         ICustomerService customerRepository,
          IMapper mapper)
        {
            _mapper = mapper?? throw new ArgumentNullException(nameof(mapper));
            _promotionService = promotionService?? throw new ArgumentNullException(nameof(_promotionService));
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
        public async Task<List<Book>> GetCustomerPromotions(Guid customerId)
        {
            return await Task.FromResult(GetUserPromotion(customerId)).ConfigureAwait(true);
        }

        /// <summary>
        /// Toggle the items in Promotion. If item doesn't exists, 
        /// it will be added to the Promotion else it will be removed.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="bookId"></param>
        /// <returns>All the items in the Promotion</returns>
       // [Authorize]
        [HttpPost]
        [Route("TogglePromotion/{customerId}/{bookId}")]
        public async Task<IEnumerable<Book>> CreatePromotion(Guid customerId, Guid bookId)
        {
            await _promotionService.TogglePromotionItem(customerId, bookId);
            return await Task.FromResult(GetUserPromotion(customerId)).ConfigureAwait(true);
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
            return _promotionService.ClearPromotion(customerId);
        }

        List<Book> GetUserPromotion(Guid customerId)
        {
            // bool user = _customerRepository.isUserExists(customerId);
            // if (user)
            // {
            //     string Promotionid = _promotionService.GetPromotionId(customerId);
            //     return _bookService.GetBooksAvailableInPromotion(Promotionid);
            // }
            // else
            // {
            //     return new List<Book>();
            // }
            throw new NotImplementedException();
        }
    }
}
