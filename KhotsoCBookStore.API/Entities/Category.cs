using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhotsoCBookStore.API.Entities
{
    public class Category: AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CategoryId { get; set; }
        
        [Required]
        [MaxLength(150)]
        public string CategoryName { get; set; }

        // [ForeignKey("BookId")]
        // public Guid BookId { get; set; }
        // public Book Book { get; set; }
    }
}
