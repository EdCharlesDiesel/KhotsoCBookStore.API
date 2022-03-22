using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhotsoCBookStore.API.Entities
{
    public abstract class Person : AuditableEntity
    {

        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(150)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

    }
}
