using KhotsoCBookStore.API.Contexts;
using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Repositories
{
    public class WishListRepository : IWishListService
    {
        readonly KhotsoCBookStoreDbContext _dbContext;

        public WishListRepository(KhotsoCBookStoreDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        public async Task CreateWishListAsync(Guid customerId)
        {            
            try
            {
                var wishList = new WishList
                {
                    WishListId = Guid.NewGuid(),
                    CustomerId = customerId,
                    CreatedOn = DateTime.Now.Date,
                };
    
                await _dbContext.WishLists.AddAsync(wishList);
                await _dbContext.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            } 
        }

        public async Task AddBookToWishListAsync(Guid customerId, Guid bookId)
        {
            try
            {
                string wishListId = await GetWishListIdAsync(customerId);
                WishListItem existingWishlistItem = _dbContext.WishListItems.FirstOrDefault(x => x.ProductId == bookId && x.WishListId.ToString() == wishListId);
    
                if (existingWishlistItem != null)
                {
                    _dbContext.WishListItems.Remove(existingWishlistItem);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    WishListItem wishListItem = new WishListItem
                    {
                        WishListId = customerId,
                        ProductId = bookId,
                    };
                    await _dbContext.WishListItems.AddAsync(wishListItem);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            } 
        }

         public  Task<string> GetWishListIdAsync(Guid customerId)
        {
            try
            {
                // var wishList = _dbContext.WishLists.FirstOrDefault(x => x.CustomerId == customerId);
    
                // if (wishList != null)
                // {
                //     return wishList.CustomerId.ToString();
                // }
                // else
                // {
                //     return await CreateWishListAsync(customerId);
                // }
                throw new NotImplementedException();
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }            
        }

        public Task UpdateWishListItems(Guid customerId)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            } 
        }       

        public Task DeleteOneWishListItem(Guid customerId, Guid bookId)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            } 
        }

        public Task<bool> SaveChangesAsync()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            } 
        }

        public Task<int> GetWishListItemsCount(Guid customerId)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            } 
        }

        public Task<int> ClearWishList(Guid customerId)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            } 
        }
    }
}