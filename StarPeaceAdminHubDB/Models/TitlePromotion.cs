using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB
{
    [Table("TitlePromotion")]
    public class TitlePromotion
    {
        [Key]
        public int PromotionNumber { get; set; } 

        public int ProductNumber { get; set; } 
       
        // dbo.TitlePromotion.PromotionNumber -> dbo.Promotion.PromotionNumber (FK_TitlePromotion_Promotion)
        [ForeignKey("PromotionNumber")]
        public Promotion Promotion { get; set; }

        // dbo.TitlePromotion.ProductNumber -> dbo.Title.ProductNumber (FK_TitlePromotion_Title)
        [ForeignKey("ProductNumber")]
        public Title Title { get; set; }
    }
}
