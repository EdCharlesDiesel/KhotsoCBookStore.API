using KhotsoCBookStore.API.Contexts;
using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Dtos;
using KhotsoCBookStore.API.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace KhotsoCBookStore.API.Repositories
{
    public class BookRepository : IBookService
    {
        readonly KhotsoCBookStoreDbContext _dbContext;

        public BookRepository(KhotsoCBookStoreDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        public List<Book> GetAllBooks()
        {
            try
            {
                return _dbContext.Books.AsNoTracking().ToList();
            }
            catch
            {
                throw;
            }
        }

        public int AddBook(Book book)
        {
            try
            {
                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public int UpdateBook(Book book)
        {
            try
            {
                Book oldBookData = GetBookData(book.BookId);

                if (oldBookData.CoverFileName != null)
                {
                    if (book.CoverFileName == null)
                    {
                        book.CoverFileName = oldBookData.CoverFileName;
                    }
                }

                _dbContext.Entry(book).State = EntityState.Modified;
                _dbContext.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public Book GetBookData(Guid bookId)
        {
            try
            {
                Book book = _dbContext.Books.FirstOrDefault(x => x.BookId == bookId);
                if (book != null)
                {
                    _dbContext.Entry(book).State = EntityState.Detached;
                    return book;
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        public string DeleteBook(Guid bookId)
        {
            try
            {
                Book book = _dbContext.Books.Find(bookId);
                _dbContext.Books.Remove(book);
                _dbContext.SaveChanges();

                return book.CoverFileName;
            }
            catch
            {
                throw;
            }
        }

        public List<Category> GetCategories()
        {
            List<Category> lstCategories = new List<Category>();
            lstCategories = (from CategoriesList in _dbContext.Categories select CategoriesList).ToList();

            return lstCategories;
        }

       
        // public List<CartItemDto> GetBooksAvailableInCart(Guid cartId)
        // {
        //     try
        //     {
        //         List<CartItemDto> cartItemList = new List<CartItemDto>();
        //         foreach (CartItem item in _dbContext.CartItems.Where(x => x.CartId == cartId).ToList())
        //         {
        //             Book book = GetBookData(item.ProductId);
        //             CartItemDto objCartItem = new CartItemDto
        //             {
        //                 Book = book,
        //                 Quantity = item.Quantity
        //             };

        //             cartItemList.Add(objCartItem);
        //         }
        //         return cartItemList;
        //     }
        //     catch
        //     {
        //         throw;
        //     }
        // }

        public List<Book> GetBooksAvailableInWishlist(Guid wishListId)
        {
            try
            {
                List<Book> wishlist = new List<Book>();
                foreach (WishListItem item in _dbContext.WishListItems.Where(x => x.WishListId == wishListId).ToList())
                {
                    // Book book = GetBookData(item.ProductId);
                    // wishlist.Add(book);
                }
                return wishlist;
            }
            catch
            {
                throw;
            }
        }

        public List<Book> GetBooksAvailableInBookSubscription(Guid bookSubscriptionId)
        {
             try
            {
                List<Book> bookSubscription = new List<Book>();
                foreach (ProductSubscriptionItem item in _dbContext.ProductSubscriptionItems.Where(x => x.ProductSubscriptionId == bookSubscriptionId).ToList())
                {
                    // Book book = GetBookData(item.ProductId);
                    // bookSubscription.Add(book);
                }
                
                return bookSubscription;
            }
            catch
            {
                throw;
            }
        }

        public List<CartDto> GetBooksAvailableInCart(string cartId)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetBooksAvailableInWishlist(string wishlistId)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetBooksAvailableInBookSubscription(string bookSubscriptionId)
        {
            throw new NotImplementedException();
        }
    }
}
