using KhotsoCBookStore.API.Models.Authors;
using Microsoft.EntityFrameworkCore;
using StarPeaceAdminHubDB;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Queries
{
    public class AuthorQuery : IAuthorQuery
    {
        private readonly MainDbContext ctx;
        public AuthorQuery(MainDbContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task<IEnumerable<AuthorInfosViewModel>> GetAllAuthors()
        {
            return await ctx.Authors.Select(m => new AuthorInfosViewModel
            {
                FirstName = m.FirstName,
                //LastName = m.LastName,
                StartPublishingDate = m.StartPublishingDate,
                EndPublishingDate = m.EndPublishingDate,
                BookStartPrice = m.BookStartPrice
            }).ToListAsync();
        }

        public async Task<AuthorInfosViewModel> GetAuthorById(int authorId)
        {
            return await ctx.Authors.Select(m => new AuthorInfosViewModel
            {
                FirstName = m.FirstName,
               // LastName = m.LastName,
                StartPublishingDate = m.StartPublishingDate,
                EndPublishingDate = m.EndPublishingDate,
                BookStartPrice = m.BookStartPrice
            }).FirstOrDefaultAsync();
        }
    }
}
