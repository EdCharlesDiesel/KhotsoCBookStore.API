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
            _dbContext = dbContext;
        }

        public void ToggleWishlistItem(int userId, int bookId)
        {
            string wishlistId = GetWishlistId(userId);
            WishListItem existingWishlistItem = _dbContext.WishListItems.FirstOrDefault(x => x.ProductId == bookId && x.WishListId == wishlistId);

            if (existingWishlistItem != null)
            {
                _dbContext.WishListItems.Remove(existingWishlistItem);
                _dbContext.SaveChanges();
            }
            else
            {
                WishListItem wishlistItem = new WishListItem
                {
                    WishListId = wishlistId,
                    ProductId = bookId,
                };
                _dbContext.WishListItems.Add(wishlistItem);
                _dbContext.SaveChanges();
            }
        }

        public int ClearWishlist(int userId)
        {
            try
            {
                string wishlistId = GetWishlistId(userId);
                List<WishListItem> wishlistItem = _dbContext.WishListItems.Where(x => x.WishListId == wishlistId).ToList();

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

        public string GetWishlistId(int userId)
        {
            try
            {
                WishList wishlist = _dbContext.WishLists.FirstOrDefault(x => x.UserId == userId);

                if (wishlist != null)
                {
                    return wishlist.WishlistId;
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

        string CreateWishlist(int userId)
        {
            try
            {
                WishList wishList = new WishList
                {
                    WishlistId = Guid.NewGuid().ToString(),
                    UserId = userId,
                    DateCreated = DateTime.Now.Date
                };

                _dbContext.WishLists.Add(wishList);
                _dbContext.SaveChanges();

                return wishList.WishlistId;
            }
            catch
            {
                throw;
            }
        }
    }
}
