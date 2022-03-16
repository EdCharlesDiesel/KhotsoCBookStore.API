using KhotsoCBookStore.API.Entities;
using System.Collections.Generic;

namespace KhotsoCBookStore.API.Services
{
    public interface IProductSubscriptionService
    {
        void ToggleBookSubscriptionItem(int userId, int bookId);
        int ClearBookSubscription(int userId);
        string GetBookSubscriptionId(int userId);      
    }
}
