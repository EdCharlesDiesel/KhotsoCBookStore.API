using System;
using System.Collections.Generic;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Dtos
{
    public class ProductSubscriptionForUpdateDto
    {

        public Guid CustomerId { get; set; }

        public DateTime DateOfSubscription { get; set; }

        public ICollection<ProductSubscriptionItem> ProductSubscriptionItems { get; set; } = new List<ProductSubscriptionItem>();

    }
}

