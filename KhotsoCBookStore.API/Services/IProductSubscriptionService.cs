namespace KhotsoCBookStore.API.Services
{
    public interface IProductSubscriptionService
    {
        void ToggleProductSubscriptionItem(int userId, int productId);
        int ClearProductSubscription(int userId);
        string GetProductSubscriptionId(int userId);      
    }
}
