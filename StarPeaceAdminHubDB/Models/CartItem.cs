using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB.Models
{
    public class CartItem : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CartItemId { get; set; } = Guid.NewGuid();

        [ForeignKey("CartId")]
        public Guid CartId { get; set; }
        

        [ForeignKey("CartId")]
        public Guid BookId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
