using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StarPeaceAdminHubDB.Contexts;

namespace StarPeaceAdminHub.Queries
{
    public class CategoryListQuery : ICategoryListQuery
    {
        MainDbContext ctx;
        public CategoryListQuery(MainDbContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task<IEnumerable<SelectListItem>> AllCategorys()
        {
            return (await ctx.Categories.Select(m => new
            {
                Text = m.CategoryName,
                Value = m.Id
            })
            .OrderBy(m => m.CategoryName)
            .ToListAsync())
            .Select(m => new SelectListItem
            {
                Text = m.Text,
                Value = m.Value.ToString()
            });
        }
    }
}
