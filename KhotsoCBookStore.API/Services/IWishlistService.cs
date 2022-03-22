using System;

namespace KhotsoCBookStore.API.Services
{
    public interface IWishListService
    {
        void ToggleWishlistItem(Guid userId, Guid bookId);
        int ClearWishlist(Guid userId);
        string GetWishlistId(Guid userId);
    }
}
