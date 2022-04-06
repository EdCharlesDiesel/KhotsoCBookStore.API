using System;

namespace KhotsoCBookStore.API.Dtos
{
    public class ProductSubscriptionItemForCreateDto
    {
        public Guid ProductSubscriptionId { get; set; }

        public string NameOfSubscription { get; set; }

        public Guid ProductId { get; set; }
    }
}