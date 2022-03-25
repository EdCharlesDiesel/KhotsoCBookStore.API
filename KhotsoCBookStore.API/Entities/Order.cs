using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace KhotsoCBookStore.API.Entities
{
    public class Order: AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OrderId { get; set; }  = Guid.NewGuid();
  
        public decimal CartTotal { get; set; }

        [ForeignKey("CustomerId")]
        public Guid CustomerId { get; set; }
        // public Customer Customer { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }
        
        public DateTime ShipDate { get; set; }
        
        public string ShipAddress { get; set; }

      //  public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
