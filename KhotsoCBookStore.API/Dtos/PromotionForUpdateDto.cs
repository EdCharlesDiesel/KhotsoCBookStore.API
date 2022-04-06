using System;
using System.ComponentModel.DataAnnotations;

namespace KhotsoCBookStore.API.Dtos
{
    public class PromotionForUpdateDto
    {
        
        [Required(ErrorMessage ="Please provide minimum retail price")]
        public decimal MinimumRetail { get; set; }
        
        [Required(ErrorMessage ="Please provide maximum retail price")]
        public decimal MaximumRetail { get; set; }   
    }
}