using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace KhotsoCBookStore.API.Entities
{
    [Table("Orders")]
    public class Order: AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OrderId { get; set; }  
        

        [ForeignKey(nameof(Customer))]
        public Guid CustomerId { get; set; }

        [ForeignKey(nameof(Book))]
        public Guid BookId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }
        
        public DateTime ShipDate { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(7,4)")]
        public decimal CartTotal { get; set; }

        public CardInfo CardInfo { get; set; }
        public Address ShippingAddress { get; set; }

       public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
