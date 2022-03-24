using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KhotsoCBookStore.API.Dtos
{
    public class PromotionDto
    {
        public Guid PromotionId { get; set; }
   
        public decimal MinimumRetail { get; set; }

        public decimal MaximumRetail { get; set; }
    }
}