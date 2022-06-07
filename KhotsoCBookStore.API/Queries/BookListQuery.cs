using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Models;
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
            return await ctx.Books.Select(o => new BookInfosViewModel
            {
                BookId = o.Id,
                Title = o.Title,
                ISBN = o.ISBN,
                PublishingDate = o.PublishingDate,
                UnitCost = o.UnitCost,
                SupplierId = o.SupplierId,
                UnitPrice = o.UnitPrice,
                UnitsInStock = o.UnitsInStock,
                UnitsOnOrder = o.UnitsOnOrder,
                ReorderLevel = o.ReorderLevel,
                Discontinued = o.Discontinued

            }).ToListAsync();

        }

        public Task<BookInfosViewModel> GetBookById(int bookId)
        {
            throw new NotImplementedException();
        }
    }
}
