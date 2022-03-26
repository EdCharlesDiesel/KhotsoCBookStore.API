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
        

        [ForeignKey("CustomerId")]
        public Guid CustomerId { get; set; }

        [ForeignKey("BookId")]
        public Guid BookId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }
        
        public DateTime ShipDate { get; set; }
        
        public string ShipAddress { get; set; }

        public decimal CartTotal { get; set; }

       public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
