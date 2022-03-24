using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhotsoCBookStore.API.Entities
{
    [Table("Subscriptions")]
    public class ProductSubscription : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProductSubscriptionId { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(Customer))]
        public Guid CustomerId { get; set; }

        [Required]
        public DateTime DateOfSubscription { get; set; }

        public ICollection<ProductSubscriptionItem> ProductSubscriptionItems { get; set; } = new List<ProductSubscriptionItem>();

    }
}
