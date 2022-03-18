using System;
using KhotsoCBookStore.API.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KhotsoCBookStore.API.Authentication
{
    public class UserType : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserTypeId { get; set; } =Guid.NewGuid();

        [Required]
        [MaxLength(150)]
        public string UserTypeName { get; set; }

        // [ForeignKey("CustomerId")]
        // public Customer Customer { get; set; }
        // public Guid CustomerId { get; set; }

    }
}
