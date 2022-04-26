using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StarPeaceAdminHubDB.Models
{
    [Table("Promotions")]
    public class Promotion: AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PromotionId { get; set; }
        
        public decimal MinimumRetail { get; set; }

        public decimal MaximumRetail { get; set; }
    }
}