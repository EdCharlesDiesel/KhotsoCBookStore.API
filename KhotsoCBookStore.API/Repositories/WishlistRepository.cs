using KhotsoCBookStore.API.Contexts;
using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KhotsoCBookStore.API.Repositories
{
    public class WishListRepository : IWishListService
    {
        readonly KhotsoCBookStoreDbContext _dbContext;

        public WishListRepository(KhotsoCBookStoreDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        public void ToggleWishlistItem(Guid userId, Guid bookId)
        {
            string wishlistId = GetWishlistId(userId);
            WishListItem existingWishlistItem = _dbContext.WishListItems.FirstOrDefault(x => x.ProductId == bookId && x.WishListId.ToString() == wishlistId);

            if (existingWishlistItem != null)
            {
                _dbContext.WishListItems.Remove(existingWishlistItem);
                _dbContext.SaveChanges();
            }
            else
            {
                WishListItem wishlistItem = new WishListItem
                {
                    WishListId = userId,
                    ProductId = bookId,
                };
                _dbContext.WishListItems.Add(wishlistItem);
                _dbContext.SaveChanges();
            }
        }

        public int ClearWishlist(Guid userId)
        {
            try
            {
                string wishlistId = GetWishlistId(userId);
                List<WishListItem> wishlistItem = _dbContext.WishListItems.Where(x => x.WishListId.ToString() == wishlistId).ToList();

                if (!string.IsNullOrEmpty(wishlistId))
                {
                    foreach (WishListItem item in wishlistItem)
                    {
                        _dbContext.WishListItems.Remove(item);
                        _dbContext.SaveChanges();
                    }
                }
                return 0;
            }
            catch
            {
                throw;
            }
        }

        public string GetWishlistId(Guid userId)
        {
            try
            {
                WishList wishlist = _dbContext.WishLists.FirstOrDefault(x => x.CustomerId == userId);

                if (wishlist != null)
                {
                    return wishlist.CustomerId.ToString();
                }
                else
                {
                    return CreateWishlist(userId);
                }
            }
            catch
            {
                throw;
            }
        }

        string CreateWishlist(Guid userId)
        {
            try
            {
                WishList wishList = new WishList
                {
                    WishlistId = Guid.NewGuid(),
                    CustomerId = userId,
                    CreatedOn = DateTime.Now.Date
                };

                _dbContext.WishLists.Add(wishList);
                _dbContext.SaveChanges();

                return wishList.CustomerId.ToString();
            }
            catch
            {
                throw;
            }
        }
    }
}
