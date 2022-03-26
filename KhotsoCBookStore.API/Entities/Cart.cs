using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhotsoCBookStore.API.Entities
{
    public class Cart : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CartId { get; set; } = Guid.NewGuid();

        [ForeignKey("CustomerId")]
        public Guid CustomerId { get; set; }        

        public decimal CartTotal { get; set; }

    }
}
