using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhotsoCBookStore.API.Entities
{
    [Table("Publishers")]
    public class Publisher : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PublisherId { get; set; } = Guid.NewGuid();

        [Required]
        public string NameAndSurname { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [MaxLength(20)]
        public int PhoneNumber { get; set; }
    }
}