using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KhotsoCBookStore.API.Entities
{
    public class Book: AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BookId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        public DateTime PublishingDate { get; set; }
        
        [ForeignKey("PublisherId")]
        public Guid PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        
        public string Category { get; set; }
        
        public decimal PurchasePrice { get; set; }        
        
        public string CoverFileName { get; set; }
    }
}
