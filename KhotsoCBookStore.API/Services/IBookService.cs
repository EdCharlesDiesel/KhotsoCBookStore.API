using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Dtos;
using System.Collections.Generic;
using System;

namespace KhotsoCBookStore.API.Services
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        int AddBook(Book book);
        int UpdateBook(Book book);
        Book GetBookData(Guid bookId);
        string DeleteBook(Guid bookId);
        List<Category> GetCategories();       
        List<CartItemDto> GetBooksAvailableInCart(string cartId);
        List<Book> GetBooksAvailableInWishlist(string wishlistId);
        List<Book> GetBooksAvailableInBookSubscription(string bookSubscriptionId);
    }
}
