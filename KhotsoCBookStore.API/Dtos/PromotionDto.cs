using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KhotsoCBookStore.API.Entities
{
    public class PromotionDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PromoId { get; set; }
        
        public decimal MaximumRetail { get; set; }

        public decimal ManimumRetail { get; set; }
    }
}