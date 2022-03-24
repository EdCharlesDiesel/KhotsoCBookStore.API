using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KhotsoCBookStore.API.Entities
{
    [Table("Promotions")]
    public class Promotion : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PromotionId { get; set; } = Guid.NewGuid();
        
        [Required]
         [Column(TypeName = "decimal(7,4)")]
        public decimal MinimumRetail { get; set; }

        [Required]
         [Column(TypeName = "decimal(7,4)")]
        public decimal MaximumRetail { get; set; }
    }
}