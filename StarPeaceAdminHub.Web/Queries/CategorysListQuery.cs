using Microsoft.EntityFrameworkCore;
using StarPeaceAdminHub.Models.Categorys;
using StarPeaceAdminHubDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Queries
{
    // The query object is automatically injected into the application DB context. 
    // The GetAllCategorys method uses LINQ to project all of the required information
    // into CategoryInfosViewModel and sorts all results in descending order on the
    // EndValidityDate property.
    public class CategorysListQuery : ICategorysListQuery
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
