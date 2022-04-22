using Microsoft.EntityFrameworkCore;
using StarPeaceAdminHub.Models.Books;
using StarPeaceAdminHubDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Queries
{
    public class BooksListQuery:IBooksListQuery
    {
        MainDbContext ctx;
        public BooksListQuery(MainDbContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task<IEnumerable<BookInfosViewModel>> GetAllBooks()
        {
            return await ctx.Books.Select(m => new BookInfosViewModel
            {
                StartValidityDate = m.StartValidityDate,
                EndValidityDate = m.EndValidityDate,
                Name = m.Name,
                DurationInDays = m.DurationInDays,
                Id = m.Id,
                Price = m.Price,
                DestinationName = m.MyDestination.Name,
                DestinationId = m.DestinationId
            })
                .OrderByDescending(m=> m.EndValidityDate)
                .ToListAsync();
        }
    }
}
