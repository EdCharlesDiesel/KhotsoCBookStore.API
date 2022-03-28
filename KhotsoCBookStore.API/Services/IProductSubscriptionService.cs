using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Services
{
    public interface IProductSubscriptionService
    {
        Task<IEnumerable<Book>> GetAllBookSubscriptionsAsync();

        Task<string> GetProductSubscriptionById(Guid customerId);

        Task CreateProductSubscriptionAsync(Guid customerId);
        
        Task<int> ClearProductSubscriptionAsync(Guid customerId);

        Task<bool> SaveChangesAsync();

        Task CreateProductSubscriptionItemAsync(Guid customerId, Guid bookId);
    }
}
