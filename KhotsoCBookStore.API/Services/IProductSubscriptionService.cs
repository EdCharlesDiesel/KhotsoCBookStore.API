using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Services
{
    public interface IProductSubscriptionService
    {
        Task CreateProductSubscriptionItemAsync(Guid customerId, Guid productId);

        Task CreateProductSubscriptionAsync(Guid customerId);

        Task<IEnumerable<Book>> GetAllBookSubscriptionsAsync();

        Task<string> GetProductSubscriptionById(Guid customerId);       
        
        Task<int> ClearProductSubscriptionAsync(Guid customerId);

        Task<bool> SaveChangesAsync();       
    }
}
