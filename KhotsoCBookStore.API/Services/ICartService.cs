using System;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Services
{
    public interface ICartService
    {
        Task AddBookToCart(Guid customerId, Guid bookId);
        
        Task RemoveCartItem(Guid customerId, Guid bookId);
        
        Task DeleteOneCartItem(Guid customerId, Guid bookId);
        
        Task<int> GetCartItemCount(Guid customerId);
        
        Task MergeCart(Guid tempCustomerId, Guid permCustomerId);
        
        Task<int> ClearCart(Guid customerId);
        
        Task<string> GetCartId(Guid customerId);
    }
}
