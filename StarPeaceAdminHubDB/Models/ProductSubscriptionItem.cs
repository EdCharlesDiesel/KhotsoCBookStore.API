using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB.Models
{
    public class ProductSubscriptionItem : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProductSubscriptionItemId { get; set; }  =Guid.NewGuid();
        
        [ForeignKey("ProductSubscriptionId")]
        public Guid ProductSubscriptionId { get; set; }
        public ProductSubscription ProductSubscription { get; set; }
        
        public Guid ProductId { get; set; }
    }
}
