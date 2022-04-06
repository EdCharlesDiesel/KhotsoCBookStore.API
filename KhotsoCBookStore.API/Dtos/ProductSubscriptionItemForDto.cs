using System;

namespace KhotsoCBookStore.API.Dtos
{
    public class ProductSubscriptionItemDto
    {
        public Guid ProductSubscriptionItemId { get; set; }
        
        public Guid ProductSubscriptionId { get; set; }

        public string NameOfSubscription { get; set; }

        public Guid ProductId { get; set; }
    }
}