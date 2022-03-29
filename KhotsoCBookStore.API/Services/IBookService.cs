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
        
        Task<IEnumerable<Category>> GetCategories();       
        
        Task<IEnumerable<CartItem>> GetBooksAvailableInCartAsync(Guid cartId);
        
        Task<IEnumerable<Book>> GetBooksAvailableInWishlistAsync(Guid wishlistId);
        
        Task<IEnumerable<Book>> GetBooksAvailableInBookSubscriptionAsync(Guid productctSubscriptionId);
        
        Task<IEnumerable<Book>> GetBooksAvailableInPromotionAsync(Guid promotionId);
        
    }
}
