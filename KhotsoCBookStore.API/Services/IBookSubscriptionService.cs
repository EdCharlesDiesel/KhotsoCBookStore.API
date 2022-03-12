using KhotsoCBookStore.API.Entities;
using System.Collections.Generic;

namespace KhotsoCBookStore.API.Services
{
    public interface IBookSubscriptionService
    {
        void ToggleBookSubscriptionItem(int userId, int bookId);
        int ClearBookSubscription(int userId);
        string GetBookSubscriptionId(int userId);      
    }
}
