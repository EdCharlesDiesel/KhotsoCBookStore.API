using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Dtos;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Services
{
    public interface IBookService
    {
        Task CreateBookAsync(Book newbook);

        Task<IEnumerable<Book>> GetAllBooksAync();
        
        Task<Book> GetBookByIdAsync(Guid bookId);
        
        Task UpdateBookAsync(Book oldBookToUpdate);
        
        void DeleteBook(Book bookToDelete);

        Task<bool> SaveChangesAsync();

        Task<bool> BookIfExistsAsync(Guid booksId);        
        
    }
}
