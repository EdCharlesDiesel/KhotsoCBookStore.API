// using KhotsoCBookStore.API.Contexts;
// using KhotsoCBookStore.API.Entities;
// using KhotsoCBookStore.API.Dtos;
// using KhotsoCBookStore.API.Services;
// using Microsoft.EntityFrameworkCore;
// using System.Collections.Generic;
// using System.Linq;
// using System;
// using System.Threading.Tasks;
// using KhotsoCBookStore.API.Helpers;

// namespace KhotsoCBookStore.API.Repositories
// {
//     public class BookRepository : IBookService
//     {
//         readonly KhotsoCBookStoreDbContext _dbContext;

//         public BookRepository(KhotsoCBookStoreDbContext dbContext)
//         {
//             _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
//         }

//         public async Task<IEnumerable<Book>> GetAllBooksAync()
//         {
//             try
//             {
//                 return await _dbContext.Books.OrderBy(b => b.Title).ToListAsync();
//             }
//             catch (System.Exception ex)
//             {
//                 throw new AggregateException(ex.Message);
//             }
//         }

//         public async Task<Book> GetBookByIdAsync(Guid bookId)
//         {
//             try
//             {
//                 return await _dbContext.Books.FirstOrDefaultAsync(b=>b.BookId==bookId);
//             }
//             catch (System.Exception ex)
//             {
//                 throw new AggregateException(ex.Message);
//             }
//         }

//         public async Task CreateBookAsync(Book book)
//         {
//             try
//             {
//                 if (book != null)
//                 {
//                     await _dbContext.AddAsync(book);
//                 }    
//             }
//             catch (System.Exception ex)
//             {
//                 throw new AggregateException(ex.Message);
//             }
//         }

//         public Task<Book> UpdateBookAsync(Book book)
//         {
//             throw new NotImplementedException();
//             // Book oldBookData = GetBookData(book.BookId);

//             // if (oldBookData.CoverFileName != null)
//             // {
//             //     if (book.CoverFileName == null)
//             //     {
//             //         book.CoverFileName = oldBookData.CoverFileName;
//             //     }
//             // }

//             // _dbContext.Entry(book).State = EntityState.Modified;
//             // _dbContext.SaveChanges();

//             // return 1;
//         }

//         public async Task DeleteBookAsync(Guid bookId)
//         {
//             try
//             {
//                 Book book = _dbContext.Books.Find(bookId);
//                 _dbContext.Books.Remove(book);
//                 await _dbContext.SaveChangesAsync();
//             }
//              catch (System.Exception ex)
//             {
//                 throw new AggregateException(ex.Message);
//             }
//         }

//         public async Task<bool> BookIfExistsAsync(Guid bookId)
//         {
//             try
//             {
//                 Book book = await _dbContext.Books.FindAsync(bookId);
//                 if (book!=null)
//                 {
//                     return true;
//                 }
//                 return false;
//             }
//             catch (System.Exception ex)
//             {
//                 throw new AggregateException(ex.Message);
//             }
//         }

//         public async Task<bool> SaveChangesAsync()
//         {
//             // try
//             // {
//                 return (await _dbContext.SaveChangesAsync() >= 0);
//             // }
//             // catch (System.Exception ex)
//             // {
//             //     throw new AggregateException(ex.Message);
//             // }
//         }


//         public async Task<IEnumerable<Category>> GetCategories()
//         {
//             try
//             {
//                 return await _dbContext.Categories.ToListAsync();
//             }
//             catch (System.Exception ex)
//             {
//                 throw new AggregateException(ex.Message);
//             }
//         }


//         public async Task<IEnumerable<CartItemDto>> GetBooksAvailableInCartAsync(Guid cartId)
//         {
//             try
//             {
//                 List<CartItemDto> cartItemList = new List<CartItemDto>();
//                 foreach (CartItem item in _dbContext.CartItems.Where(x => x.CartId == cartId).ToList())
//                 {
//                     Book book = await GetBookByIdAsync(item.ProductId);
//                     CartItemDto objCartItem = new CartItemDto
//                     {
//                         CartItemId = item.CartItemId,
//                         Quantity = item.Quantity,
//                         ProductId = item.ProductId
//                     };

//                     cartItemList.Add(objCartItem);
//                 }
//                 return cartItemList;

//                 throw new NotImplementedException();
//             }
//           catch (System.Exception ex)
//             {
//                 throw new AggregateException(ex.Message);
//             }
//         }

//         public async Task<IEnumerable<Book>> GetBooksAvailableInWishlistAsync(Guid wishListId)
//         {
//             try
//             {
//                 List<Book> wishlist = new List<Book>();
//                 foreach (WishListItem item in _dbContext.WishListItems.Where(x => x.WishListId == wishListId).ToList())
//                 {
//                     Book book = await GetBookByIdAsync(item.ProductId);
//                     // wishlist.Add(book);
//                 }
//                 return wishlist;
//             }
//             catch (System.Exception ex)
//             {
//                 throw new AggregateException(ex.Message);
//             }
//         }

//         public async Task<IEnumerable<Book>> GetBooksAvailableInBookSubscriptionAsync(Guid bookSubscriptionId)
//         {
//             try
//             {
//                 List<Book> bookSubscription = new List<Book>();
//                 foreach (ProductSubscriptionItem item in _dbContext.ProductSubscriptionItems.Where(x => x.ProductSubscriptionId == bookSubscriptionId).ToList())
//                 {
//                      Book book = await GetBookByIdAsync(item.ProductId);
//                     // bookSubscription.Add(book);
//                 }

//                 return bookSubscription;
//             }
//          catch (System.Exception ex)
//             {
//                 throw new AggregateException(ex.Message);
//             }
//         }

//         public  Task<IEnumerable<Book>> GetBooksAvailableInPromotionAsync(Guid promotionid)
//         {
//             try
//             {
//                 // List<Book> bookPromotion = new List<Book>();
//                 // foreach (PromotionItem item in _dbContext.ProductSubscriptionItems.Where(x => x.ProductSubscriptionId == bookSubscriptionId).ToList())
//                 // {
//                 //      Book book = await GetBookByIdAsync(item.ProductId);
//                 //     // bookSubscription.Add(book);
//                 // }
//                 throw new NotImplementedException();
//             }
//             catch (System.Exception ex)
//             {
//                 throw new AggregateException(ex.Message);
//             }
//         }
//     }
// }
