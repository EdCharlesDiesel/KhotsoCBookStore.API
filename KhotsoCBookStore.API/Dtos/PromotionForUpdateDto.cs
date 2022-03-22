using System;


namespace KhotsoCBookStore.API.Entities
{
    public class PromotionForUpdateDto
    {
        public Guid PromoId { get; set; }
        
        public decimal MaximumRetail { get; set; }

        public decimal ManimumRetail { get; set; }
    }
}