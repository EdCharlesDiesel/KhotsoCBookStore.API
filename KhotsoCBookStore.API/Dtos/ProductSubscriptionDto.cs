using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Dtos
{
    public class ProductSubscriptionDto
    {
        public Guid ProductSubcriptionId { get; set; }

        public Guid CustomerId { get; set; }
        [Required(ErrorMessage ="Please provide subscription date")]
        public DateTime DateOfSubscription { get; set; }

        public ICollection<ProductSubscriptionItem> ProductSubscriptionItems { get; set; } = new List<ProductSubscriptionItem>();

    }
}

   