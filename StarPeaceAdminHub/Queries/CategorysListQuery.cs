using Microsoft.EntityFrameworkCore;
using StarPeaceAdminHub.Models.Categorys;
using StarPeaceAdminHubDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Queries
{
    public class CategorysListQuery:ICategorysListQuery
    {
        MainDbContext ctx;
        public CategorysListQuery(MainDbContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task<IEnumerable<CategoryInfosViewModel>> GetAllCategorys()
        {
            return await ctx.Categorys.Select(m => new CategoryInfosViewModel
            {
                Id = m.Id,
                CategoryName = m.CategoryName,
                BookId = m.BookId
            })
                .OrderByDescending(m=> m.CategoryName)
                .ToListAsync();
        }
    }
}
