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
        
        Task CreateBook(Book book);
        
        Task<Book> UpdateBook(Book book);
        
        Task<Book> GetBookByIdAsync(Guid bookId);

        Task<bool> SaveChangesAsync();
        
        void DeleteBook(Book booksEntity);
        
        Task<IEnumerable<Category>> GetCategories();       
        
        Task<IEnumerable<CartItemDto>> GetBooksAvailableInCartAsync(Guid cartId);
        
        Task<IEnumerable<Book>> GetBooksAvailableInWishlist(Guid wishlistId);
        
        Task<IEnumerable<Book>> GetBooksAvailableInBookSubscription(Guid bookSubscriptionId);
        
        Task<IEnumerable<Book>> GetBooksAvailableInPromotion(Guid promotionId);
        Task<bool> BookIfExistsAsync(Guid booksId);
    }
}
