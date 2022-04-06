using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhotsoCBookStore.API.Entities
{
    [Table("OrderItems")]
    public class OrderItem: AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OrderItemId { get; set; } 

        [ForeignKey(nameof(Order))]
        public Guid OrderId { get; set; }
        
        public Guid BookId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }
         [Column(TypeName = "decimal(7,4)")]
        public decimal Price { get; set; }
    }
}
