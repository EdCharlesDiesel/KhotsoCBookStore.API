namespace StarPeaceAdminHubDB
{
    [Table("TitlePromotion")]
    public class TitlePromotion
    {
        [Column(Name = "PromotionNumber", TypeName = "int")]
        [Required(ErrorMessage = "Promotion Number is required")]
        public int PromotionNumber { get; set; } // int, not null

        [Column(Name = "ProductNumber", TypeName = "int")]
        [Required(ErrorMessage = "Product Number is required")]
        public int ProductNumber { get; set; } // int, not null

        // dbo.TitlePromotion.PromotionNumber -> dbo.Promotion.PromotionNumber (FK_TitlePromotion_Promotion)
        [ForeignKey("PromotionNumber")]
        public Promotion Promotion { get; set; }

        // dbo.TitlePromotion.ProductNumber -> dbo.Title.ProductNumber (FK_TitlePromotion_Title)
        [ForeignKey("ProductNumber")]
        public Title Title { get; set; }
    }
}
