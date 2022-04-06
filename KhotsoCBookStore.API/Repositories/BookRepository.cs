using KhotsoCBookStore.API.Contexts;
using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Repositories
{
    public class BookRepository : IBookService
    {
        readonly KhotsoCBookStoreDbContext _dbContext;

        public BookRepository(KhotsoCBookStoreDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        public async Task CreateBookAsync(Book book)
        {
            try
            {
                if (book != null)
                {
                    await _dbContext.AddAsync(book);
                }    
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public async Task<IEnumerable<Book>> GetAllBooksAync()
        {
            try
            {
                return await _dbContext.Books.OrderBy(b => b.Title).ToListAsync();
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public async Task<Book> GetBookByIdAsync(Guid bookId)
        {
            try
            {
                return await _dbContext.Books.FirstOrDefaultAsync(b=>b.BookId==bookId);
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }       

        public  Task UpdateBookAsync(Book oldBookToUpdate)
        {
            try
            {                    
                // Book oldBookData = GetBookData(book.BookId);

                // if (oldBookData.CoverFileName != null)
                // {
                //     if (book.CoverFileName == null)
                //     {
                //         book.CoverFileName = oldBookData.CoverFileName;
                //     }
                // }

                // _dbContext.Entry(book).State = EntityState.Modified;
                // _dbContext.SaveChanges();  
                throw new NotImplementedException();              
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public void DeleteBook(Book bookToDelete)
        {
            try
            {
                _dbContext.Books.Remove(bookToDelete);
                
            }
             catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public async Task<bool> BookIfExistsAsync(Guid bookId)
        {
            try
            {
                Book book = await _dbContext.Books.FindAsync(bookId);
                if (book!=null)
                {
                    return true;
                }
                return false;
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {          
           try
           {
                return (await _dbContext.SaveChangesAsync() >= 0);
           }
           catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }       
        }
    }
}
