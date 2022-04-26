﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB.Models
{
    [Table("Categories")]
    public class Category: AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CategoryId { get; set; } 
        
        [Required]
        [MaxLength(150)]
        public string CategoryName { get; set; }        
        
        public Book Book { get; set; }

        public Guid BookId { get; set; }
    }
}
