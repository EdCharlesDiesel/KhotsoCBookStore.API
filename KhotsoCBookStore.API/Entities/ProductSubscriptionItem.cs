using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhotsoCBookStore.API.Entities
{
    [Table("SubscriptionItems")]
    public class ProductSubscriptionItem : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProductSubscriptionItemId { get; set; }

        [ForeignKey(nameof(ProductSubscription))]
        public Guid ProductSubscriptionId { get; set; }

        public string NameOfSubscription { get; set; }

        public Guid ProductId { get; set; }
    }
}
