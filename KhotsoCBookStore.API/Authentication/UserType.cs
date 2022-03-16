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
        public Guid UserTypeId { get; set; }

        [Required]
        [MaxLength(150)]
        public string UserTypeName { get; set; }

    }
}
