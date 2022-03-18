// using System.Collections.Generic;
// using System.Threading.Tasks;
// using KhotsoCBookStore.API.Entities;
// using KhotsoCBookStore.API.Services;
// using Microsoft.AspNetCore.Mvc;
// using System;
// using AutoMapper;

// namespace KhotsoCBookStore.API.Controllers
// {
//     [Route("api/Promotion")]
//     public class PromotionsController : Controller
//     {
//         readonly IPromotionService _promotionService;
//         readonly IBookService _bookService;
//         readonly ICustomerService _customerRepository;

//         private IMapper _mapper;

//         public PromotionsController(
//             IPromotionService promotionService, 
//         IBookService bookService,
//          ICustomerService customerRepository,
//           IMapper mapper)
//         {
//             _mapper = mapper?? throw new ArgumentNullException(nameof(mapper));
//             _promotionService = promotionService?? throw new ArgumentNullException(nameof(_promotionService));
//             _bookService = bookService?? throw new ArgumentNullException(nameof(_bookService));
//             _customerRepository = customerRepository?? throw new ArgumentNullException(nameof(_customerRepository));
//         }

//         /// <summary>
//         /// Get the list of items in the Promotion
//         /// </summary>
//         /// <param name="userId"></param>
//         /// <returns>All the items in the Promotion</returns>
//         [HttpGet("{userId}")]
//         public async Task<List<Book>> Get(Guid userId)
//         {
//             return await Task.FromResult(GetUserPromotion(userId)).ConfigureAwait(true);
//         }

//         /// <summary>
//         /// Toggle the items in Promotion. If item doesn't exists, it will be added to the Promotion else it will be removed.
//         /// </summary>
//         /// <param name="userId"></param>
//         /// <param name="bookId"></param>
//         /// <returns>All the items in the Promotion</returns>
//        // [Authorize]
//         [HttpPost]
//         [Route("TogglePromotion/{userId}/{bookId}")]
//         public async Task<List<Book>> Post(Guid userId, Guid bookId)
//         {
//             _promotionService.TogglePromotionItem(userId, bookId);
//             return await Task.FromResult(GetUserPromotion(userId)).ConfigureAwait(true);
//         }

//         /// <summary>
//         /// Clear the Promotion
//         /// </summary>
//         /// <param name="userId"></param>
//         /// <returns></returns>
//         ///[Authorize]
//         [HttpDelete("{userId}")]
//         public Task Delete(Guid userId)
//         {
//             return _promotionService.ClearPromotion(userId);
//         }

//         List<Book> GetUserPromotion(Guid userId)
//         {
//             // bool user = _customerRepository.isUserExists(userId);
//             // if (user)
//             // {
//             //     string Promotionid = _promotionService.GetPromotionId(userId);
//             //     return _bookService.GetBooksAvailableInPromotion(Promotionid);
//             // }
//             // else
//             // {
//             //     return new List<Book>();
//             // }
//             throw new NotImplementedException();
//         }
//     }
// }
