using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB.Models
{
    [Table("Publishers")]
    public class Publisher : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PublisherId { get; set; }

        [Required]
        public string PublisherName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [MaxLength(20)]
        public int PhoneNumber { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}