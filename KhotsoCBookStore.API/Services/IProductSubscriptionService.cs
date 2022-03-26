using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KhotsoCBookStore.API.Services
{
    public interface IProductSubscriptionService
    {
        Task ToggleProductSubscriptionItem(Guid userId, Guid productId);
       
        Task<string> GetProductSubscriptionId(Guid userId);
        Task <int>ClearProductSubscriptionAsync(Guid customerId);
        Task<IEnumerable<Book>> GetProductSubscriptionId();
        Task CreateProductSubscriptionAsync(ProductSubscription productSubscriptionToCreate);
        Task SaveChangesAsync();
        Task<IEnumerable<Book>> GetProductSubscription();
        Task<ActionResult<Book>> GetProductSubscriptionById(Guid customerId);
    }
}
