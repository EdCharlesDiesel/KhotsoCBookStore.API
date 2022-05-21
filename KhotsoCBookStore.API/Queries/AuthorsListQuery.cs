// using KhotsoCBookStore.API.Models.Authors;
// using Microsoft.EntityFrameworkCore;
// using StarPeaceAdminHubDB;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace KhotsoCBookStore.API.Queries
// {
//     public class AuthorsListQuery:IAuthorsListQuery
//     {
//         private readonly MainDbContext ctx;
//         public AuthorsListQuery(MainDbContext ctx)
//         {
//             this.ctx = ctx;
//         }
//         public async Task<IEnumerable<AuthorInfosViewModel>> GetAllAuthors()
//         {
//             return await ctx.Authors.Select(m => new AuthorInfosViewModel
//             {
//                 FirstName = m.FirstName;
//             LastName = m.LastName;
//             StartPublishingDate =m.StartPublishingDate;
//             EndPublishingDate = m.EndPublishingDate;
//             BookStartPrice = m.BookStartPrice;
//             })
//                 .OrderByDescending(m=> m.EndValidityDate)
//                 .ToListAsync();
//         }
//     }
// }
