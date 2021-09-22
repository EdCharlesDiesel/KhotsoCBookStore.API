using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Models;
using System.Collections.Generic;

namespace KhotsoCBookStore.API.Services
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        int AddBook(Book book);
        int UpdateBook(Book book);
        Book GetBookData(int bookId);
        string DeleteBook(int bookId);
        List<Categories> GetCategories();       
        List<CartItemDto> GetBooksAvailableInCart(string cartId);
        List<Book> GetBooksAvailableInWishlist(string wishlistID);

        List<Book> GetBooksAvailableInBookSubscription(string bookSubscriptionId);
        
    }
}
