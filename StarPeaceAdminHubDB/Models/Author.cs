using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StarPeaceAdminHubDB.Models
{
    [Table("Author")]
    public class Author: AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AuthorId { get; set; }

        [Required(ErrorMessage = "You should provide a first name value.")]
        [MaxLength(150)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You should provide a last name value.")]
        [MaxLength(150)]
        public string LastName { get; set; }

    }
}
