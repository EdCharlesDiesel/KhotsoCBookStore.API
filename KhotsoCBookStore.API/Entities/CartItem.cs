using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhotsoCBookStore.API.Entities
{
    [Table("CartItems")]
    public class CartItem : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CartItemId { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(Cart))]
        public Guid CartId { get; set; }
        
        [ForeignKey(nameof(Book))]
        public Guid BookId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
