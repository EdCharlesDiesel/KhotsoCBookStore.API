using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhotsoCBookStore.API.Entities
{
    [Table("Categories")]
    public class Category : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CategoryId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(150)]
        public string CategoryName { get; set; }

        [ForeignKey(nameof(Book))]
        public Guid BookId { get; set; }
        
        public virtual Book Book { get; set; }
    }
}
