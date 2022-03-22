using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhotsoCBookStore.API.Entities
{
    public class Customer : Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CustomerId { get; set; } = Guid.NewGuid();
        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Province { get; set; }

        [Required]
        public int Postal { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
