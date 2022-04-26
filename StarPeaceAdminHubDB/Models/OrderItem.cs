using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB.Models
{
    [Table("OrderItems")]
    public class OrderItem: AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OrderItemId { get; set; }

        public Guid OrderId { get; set; }

        public Order Order { get; set; }
        
        public Guid BookId { get; set; }

        public int Quantity { get; set; }

    }
}
