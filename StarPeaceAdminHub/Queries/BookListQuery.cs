using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StarPeaceAdminHubDB;

namespace StarPeaceAdminHub.Queries
{
    public class BookListQuery : IBookListQuery
    {
        MainDbContext ctx;
        public BookListQuery(MainDbContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task<IEnumerable<SelectListItem>> AllBooks()
        {
            return (await ctx.Books.Select(m => new
            {
                Text = m.CategoryName,
                Value = m.Id
            })
            .OrderBy(m => m.Text)
            .ToListAsync())
            .Select(m => new SelectListItem
            {
                Text = m.Text,
                Value = m.Value.ToString()
            });
        }
    }
}
