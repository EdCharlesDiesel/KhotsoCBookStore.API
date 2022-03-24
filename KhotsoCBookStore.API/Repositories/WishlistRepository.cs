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

        public async Task ToggleWishListItem(Guid customerId, Guid bookId)
        {
            string wishListId = await GetWishListId(customerId);
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

        public async Task<int> ClearWishList(Guid customerId)
        {
            try
            {
                var wishListId = await GetWishListId(customerId);
                var wishListItem = _dbContext.WishListItems.Where(x => x.WishListId.ToString() == wishListId).ToList();

                if (!string.IsNullOrEmpty(wishListId))
                {
                    foreach (WishListItem item in wishListItem)
                    {
                        _dbContext.WishListItems.Remove(item);
                        _dbContext.SaveChanges();
                    }
                }
                return 0;
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public async Task<string> GetWishListId(Guid customerId)
        {
            try
            {
                var wishList = _dbContext.WishLists.FirstOrDefault(x => x.CustomerId == customerId);
    
                if (wishList != null)
                {
                    return wishList.CustomerId.ToString();
                }
                else
                {
                    return await CreateWishListAsync(customerId);
                }
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }            
        }

        private async Task<string> CreateWishListAsync(Guid customerId)
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
    
                return wishList.CustomerId.ToString();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}
