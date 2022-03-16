namespace KhotsoCBookStore.API.Services
{
    public interface IWishListService
    {
        void ToggleWishlistItem(int userId, int bookId);
        int ClearWishlist(int userId);
        string GetWishlistId(int userId);
    }
}
