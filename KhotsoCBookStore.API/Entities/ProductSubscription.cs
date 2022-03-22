using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KhotsoCBookStore.API.Authentication;

namespace KhotsoCBookStore.API.Entities
{
    public class ProductSubscription : AuditableEntity
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProductSubscriptionId { get; set; }

        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public UserMaster UserMasters { get; set; }

        public ICollection<ProductSubscriptionItem> ProductSubscriptionItems { get; set; } = new List<ProductSubscriptionItem>();

    }
}
