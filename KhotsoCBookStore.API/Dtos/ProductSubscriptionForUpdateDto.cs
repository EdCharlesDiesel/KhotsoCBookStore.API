using System;

namespace KhotsoCBookStore.API.Dtos
{
    public class ProductSubscriptionForUpdateDto
    {

        public Guid ProductSubscriptionId { get; set; }

        // [ForeignKey("UserId")]
        // public Guid UserId { get; set; }
        // public UserMaster UserMasters { get; set; }

        // public ICollection<ProductSubscriptionItem> ProductSubscriptionItems { get; set; } = new List<ProductSubscriptionItem>();

    }
}

   