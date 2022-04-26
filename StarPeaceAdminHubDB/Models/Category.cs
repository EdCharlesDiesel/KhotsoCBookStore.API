using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;

namespace StarPeaceAdminHubDB.Models
{
    [Table("Categories")]
    public class Category: Entity<int>, ICategory
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
