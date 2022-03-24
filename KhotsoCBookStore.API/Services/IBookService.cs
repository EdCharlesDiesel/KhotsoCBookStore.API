using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Dtos;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAync();
        
        Task CreateBookAsync(Book book);
        
        Task<Book> GetBookByIdAsync(Guid bookId);
        
        Task<Book> UpdateBookAsync(Book book);
        
        Task DeleteBookAsync(Guid bookId);

        Task<bool> BookIfExistsAsync(Guid booksId);

        Task<bool> SaveChangesAsync();
        
        Task<IEnumerable<Category>> GetCategories();       
        
        Task<IEnumerable<CartItemDto>> GetBooksAvailableInCartAsync(Guid cartId);
        
        Task<IEnumerable<Book>> GetBooksAvailableInWishlistAsync(Guid wishlistId);
        
        Task<IEnumerable<Book>> GetBooksAvailableInBookSubscriptionAsync(Guid bookSubscriptionId);
        
        Task<IEnumerable<Book>> GetBooksAvailableInPromotionAsync(Guid promotionId);
        
    }
}
