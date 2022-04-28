using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB.Models
{
    public class Cart 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CartId { get; set; }

        [ForeignKey("CustomerId")]
        public Guid CustomerId { get; set; }        

        public decimal CartTotal { get; set; }

    }
}
