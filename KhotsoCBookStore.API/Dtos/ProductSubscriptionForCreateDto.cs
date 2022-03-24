using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Dtos
{
    public class ProductSubscriptionForCreateDto
    {

        public Guid CustomerId { get; set; }

        public DateTime DateOfSubscription { get; set; }

        public ICollection<ProductSubscriptionItem> ProductSubscriptionItems { get; set; } = new List<ProductSubscriptionItem>();

    }
}

   