using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB.Models
{
    public class ProductSubscription : AuditableEntity
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProductSubscriptionId { get; set; }  =Guid.NewGuid();

        [ForeignKey("CustomerId")]
        public Guid CustomerId { get; set; }
        // public Customer Customer { get; set; }

       // public ICollection<ProductSubscriptionItem> ProductSubscriptionItems { get; set; } = new List<ProductSubscriptionItem>();

    }
}
