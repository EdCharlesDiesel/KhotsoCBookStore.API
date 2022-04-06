using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhotsoCBookStore.API.Entities
{
    [Table("Carts")]
    public class Cart : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CartId { get; set; } 

        [ForeignKey(nameof(Customer))]
        public Guid CustomerId { get; set; }         

        [Column(TypeName = "decimal(7,4)")]
        public decimal CartTotal { get; set; }
    }
}
