using KhotsoCBookStore.API.Contexts;
using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Dtos;
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

        public async Task<IEnumerable<Book>> GetAllBooksAync()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task CreateBook(Book book)
        { 
            if (book != null)
            {
               await _dbContext.AddAsync(book);
            }
        }

          public async Task<bool> SaveChangesAsync()
        {
            return (await _dbContext.SaveChangesAsync() >= 0);
        }
        public int UpdateBook(Book book)
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

                // return 1;

                throw new NotImplementedException();
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

       
        public List<CartItemDto> GetBooksAvailableInCart(Guid cartId)
        {
            try
            {
                // List<CartItemDto> cartItemList = new List<CartItemDto>();
                // foreach (CartItem item in _dbContext.CartItems.Where(x => x.CartId == cartId).ToList())
                // {
                //     Book book = GetBookByIdAsync(item.ProductId);
                //     CartItemDto objCartItem = new CartItemDto
                //     {
                //         Book = book,
                //         Quantity = item.Quantity
                //     };

                //     cartItemList.Add(objCartItem);
                // }
                //return cartItemList;

                throw new NotImplementedException();
            }
            catch
            {
                throw;
            }
        }

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

        public List<Book> GetBooksAvailableInPromotion(string promotionid)
        {
            throw new NotImplementedException();
        }

     
     

        Task<Book> IBookService.UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetBookByIdAsync(Guid bookId)
        {
            throw new NotImplementedException();
        }

  

        public void DeleteBook(Book booksEntity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Category>> IBookService.GetCategories()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CartItemDto>> GetBooksAvailableInCartAsync(Guid cartId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Book>> IBookService.GetBooksAvailableInWishlist(Guid wishlistId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Book>> IBookService.GetBooksAvailableInBookSubscription(Guid bookSubscriptionId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetBooksAvailableInPromotion(Guid promotionId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> BookIfExistsAsync(Guid booksId)
        {
            throw new NotImplementedException();
        }
    }
}
