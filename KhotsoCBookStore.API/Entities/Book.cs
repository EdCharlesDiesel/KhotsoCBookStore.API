using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

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
        
        public decimal Cost { get; set; }    

        public decimal RetailPrice { get; set; }     
        
        public string CoverFileName { get; set; }

    }
}
