using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace KhotsoCBookStore.API.Entities
{
    [Table("Books")]
    public class Book : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BookId { get; set; } 

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        public DateTime PublishingDate { get; set; }

        [ForeignKey(nameof(Publisher))]
        public Guid PublisherId { get; set; }

        [Column(TypeName = "decimal(7,4)")]
        public decimal Cost { get; set; }

        [Column(TypeName = "decimal(7,4)")]
        public decimal RetailPrice { get; set; }

        public string CoverFileName { get; set; }
    }
}
