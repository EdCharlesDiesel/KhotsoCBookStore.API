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
        [Column(Name = "PromotionNumber", TypeName = "int")]
        [Required(ErrorMessage = "Promotion Number is required")]
        public int PromotionNumber { get; set; } // int, not null

        [Column(Name = "PromotionReleaseDate", TypeName = "smalldatetime")]
        [Required(ErrorMessage = "Promotion Release Date is required")]
        public DateTime PromotionReleaseDate { get; set; } // smalldatetime, not null

        [Column(Name = "PromotionStatus", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Required(ErrorMessage = "Promotion Status is required")]
        public string PromotionStatus { get; set; } // nvarchar(50), not null

        [Column(Name = "PromotionType", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Required(ErrorMessage = "Promotion Type is required")]
        public string PromotionType { get; set; } // nvarchar(50), not null

        // dbo.MemberOrder.PromotionNumber -> dbo.Promotion.PromotionNumber (FK_MemberOrder_Promotion)
        public IEnumerable<MemberOrder> MemberOrders { get; set; }

        // dbo.TitlePromotion.PromotionNumber -> dbo.Promotion.PromotionNumber (FK_TitlePromotion_Promotion)
        public IEnumerable<TitlePromotion> TitlePromotions { get; set; }
    }
}
