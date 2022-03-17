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
        // List<CartItemDto> GetBooksAvailableInCart(guid cartId);
        List<Book> GetBooksAvailableInWishlist(Guid wishlistId);
        List<Book> GetBooksAvailableInBookSubscription(Guid bookSubscriptionId);
        List<Book> GetBooksAvailableInPromotion(string promotionid);
        List<CartItemDto> GetBooksAvailableInCart(string cartid);
    }
}
