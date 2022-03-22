// using System.Collections.Generic;
// using System.Threading.Tasks;
// using KhotsoCBookStore.API.Entities;
// using KhotsoCBookStore.API.Services;
// using Microsoft.AspNetCore.Mvc;
// using System;
// namespace KhotsoCBookStore.API.Controllers
// {
//     [Route("api/Promotion")]
//     public class PromotionController : Controller
//     {
//         readonly IPromotionService _promotionService;
//         readonly IBookService _bookService;
//         readonly IUserService _userService;

//         public PromotionController(IPromotionService promotionService, 
//         IBookService bookService, IUserService userService)
//         {
//             _promotionService = promotionService?? throw new ArgumentNullException(nameof(_promotionService));
//             _bookService = bookService?? throw new ArgumentNullException(nameof(_bookService));
//             _userService = userService?? throw new ArgumentNullException(nameof(_userService));
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
//         public int Delete(Guid userId)
//         {
//             return _promotionService.ClearPromotion(userId);
//         }

//         List<Book> GetUserPromotion(Guid userId)
//         {
//             bool user = _userService.isUserExists(userId);
//             if (user)
//             {
//                 string Promotionid = _promotionService.GetPromotionId(userId);
//                 return _bookService.GetBooksAvailableInPromotion(Promotionid);
//             }
//             else
//             {
//                 return new List<Book>();
//             }
//         }
//     }
// }
