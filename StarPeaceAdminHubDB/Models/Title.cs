namespace StarPeaceAdminHubDB
{
    [Table("Title")]
    public class Title
    {
        public Title()
        {
            this.TitlePromotions = new List<TitlePromotion>();
        }

        [Key]
        [Column(Name = "ProductNumber", TypeName = "int")]
        [Required(ErrorMessage = "Product Number is required")]
        public int ProductNumber { get; set; } // int, not null

        [Column(Name = "TitleOfWork", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Required(ErrorMessage = "Title Of Work is required")]
        public string TitleOfWork { get; set; } // nvarchar(50), not null

        [Column(Name = "TitleCover", TypeName = "image")]
        [Required(ErrorMessage = "Title Cover is required")]
        public byte[] TitleCover { get; set; } // image, not null

        [Column(Name = "CatelogDescription", TypeName = "nvarchar")]
        [MaxLength]
        [Required(ErrorMessage = "Catelog Description is required")]
        public string CatelogDescription { get; set; } // nvarchar(max), not null

        [Column(Name = "CopyRightDate", TypeName = "smalldatetime")]
        [Required(ErrorMessage = "Copy Right Date is required")]
        public DateTime CopyRightDate { get; set; } // smalldatetime, not null

        [Column(Name = "TitleCategory", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Required(ErrorMessage = "Title Category is required")]
        public string TitleCategory { get; set; } // nvarchar(50), not null

        [Column(Name = "CreditValue", TypeName = "smallint")]
        [Required(ErrorMessage = "Credit Value is required")]
        public short CreditValue { get; set; } // smallint, not null

        // dbo.Title.ProductNumber -> dbo.Product.ProductNumber (FK_Title_Product)
        [ForeignKey("ProductNumber")]
        public Product Product { get; set; }

        // dbo.AudioTitle.ProductNumber -> dbo.Title.ProductNumber (FK_AudioTitle_Title)
        public AudioTitle AudioTitle { get; set; }

        // dbo.BookTitle.ProductNumber -> dbo.Title.ProductNumber (FK_BookTitle_Title)
        public BookTitle BookTitle { get; set; }

        // dbo.TitlePromotion.ProductNumber -> dbo.Title.ProductNumber (FK_TitlePromotion_Title)
        public IEnumerable<TitlePromotion> TitlePromotions { get; set; }

        // dbo.VideoTitle.ProductNumber -> dbo.Title.ProductNumber (FK_VideoTitle_Title)
        public VideoTitle VideoTitle { get; set; }
    }
}
