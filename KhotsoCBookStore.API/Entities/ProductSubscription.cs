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
        public Guid ProductSubscriptionId { get; set; }

        [ForeignKey(nameof(Customer))]
        public Guid CustomerId { get; set; }

        [Required]
        public DateTime DateOfSubscription { get; set; }

    }
}
