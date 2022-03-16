using System;

namespace KhotsoCBookStore.API.Services
{
    public interface IProductSubscriptionService
    {
        void ToggleProductSubscriptionItem(Guid userId, Guid productId);
        int ClearProductSubscription(Guid userId);
        string GetProductSubscriptionId(Guid userId);      
    }
}
