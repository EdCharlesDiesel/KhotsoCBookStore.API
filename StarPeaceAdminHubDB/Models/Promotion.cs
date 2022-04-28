using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB
{
    [Table("Promotion")]
    public class Promotion
    {
        public Promotion()
        {
            this.MemberOrders = new List<MemberOrder>();
            this.TitlePromotions = new List<TitlePromotion>();
        }

        [Key]
        [Required(ErrorMessage = "Promotion Number is required")]
        public int PromotionNumber { get; set; } 

        [Required(ErrorMessage = "Promotion Release Date is required")]
        public DateTime PromotionReleaseDate { get; set; } 

        [MaxLength(50)]
        [Required(ErrorMessage = "Promotion Status is required")]
        public string PromotionStatus { get; set; } 

        [MaxLength(50)]
        [Required(ErrorMessage = "Promotion Type is required")]
        public string PromotionType { get; set; } 

        // dbo.MemberOrder.PromotionNumber -> dbo.Promotion.PromotionNumber (FK_MemberOrder_Promotion)
        public IEnumerable<MemberOrder> MemberOrders { get; set; }

        // dbo.TitlePromotion.PromotionNumber -> dbo.Promotion.PromotionNumber (FK_TitlePromotion_Promotion)
        public IEnumerable<TitlePromotion> TitlePromotions { get; set; }
    }
}
