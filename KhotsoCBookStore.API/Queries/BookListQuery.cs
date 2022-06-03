using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StarPeaceAdminHubDB;

namespace KhotsoCBookStore.API.Queries
{
    public class BookListQuery : IBooksListQuery
    {
        MainDbContext ctx;
        public BookListQuery(MainDbContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task<IEnumerable<BookInfosViewModel>> GetAllBooks()
        {
            return await ctx.Books.Select(m => new BookInfosViewModel
            {
                Id = m.Id,
                Title = m.Title,
                ISBN = m.ISBN,
                Description = m.Description,
                Cost = m.Cost,
                PublishingDate= m.PublishingDate,
                RetailPrice = m.RetailPrice,
                CoverFileName= m.CoverFileName     
           
            }).ToListAsync();
            
        }

        public Task<BookInfosViewModel> GetBookById(int authorId)
        {
            throw new NotImplementedException();
        }
    }
}
