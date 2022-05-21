using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KhotsoCBookStore.API.Dtos
{
    public class PromotionDto
    {
        public Guid PromoId { get; set; }
        
        public decimal MaximumRetail { get; set; }

        public decimal ManimumRetail { get; set; }
    }
}