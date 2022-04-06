using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Services
{
    public interface ICartService
    {
        Task CreateCartAsync(Guid customerId);

        Task AddBookToCartAsync(Guid customerId, Guid bookId);

        Task<string> GetCartIdAsync(Guid customerId);

        Task<IEnumerable<Book>> GetCartItemsAsync(Guid customerId);

        Task<int> GetCartItemCount(Guid customerId);

        Task UpdateCartItem(Guid customerId);

        Task RemoveCartItem(Guid customerId, Guid bookId);        
       
        Task<int> ClearCart(Guid customerId);

        Task<bool> SaveChangesAsync();
        
        Task MergeCart(Guid tempCustomerId, Guid permCustomerId);
    }
}
