using System;

namespace KhotsoCBookStore.API.Services
{
    public interface ICartService
    {
        void AddBookToCart(Guid userId, Guid bookId);
        void RemoveCartItem(Guid userId, Guid bookId);
        void DeleteOneCartItem(Guid userId, Guid bookId);
        int GetCartItemCount(Guid userId);
        void MergeCart(Guid tempUserId, Guid permUserId);
        int ClearCart(Guid userId);
        string GetCartId(Guid userId);
    }
}
