namespace StarPeaceAdminHubDB
{
    [Table("VideoTitle")]
    public class VideoTitle
    {
        [Key]
        [Column(Name = "ProductNumber", TypeName = "int")]
        [Required(ErrorMessage = "Product Number is required")]
        public int ProductNumber { get; set; } // int, not null

        [Column(Name = "VideoProducer", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Required(ErrorMessage = "Video Producer is required")]
        public string VideoProducer { get; set; } // nvarchar(50), not null

        [Column(Name = "VideoDirector", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Required(ErrorMessage = "Video Director is required")]
        public string VideoDirector { get; set; } // nvarchar(50), not null

        [Column(Name = "VideoCategory", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Required(ErrorMessage = "Video Category is required")]
        public string VideoCategory { get; set; } // nvarchar(50), not null

        [Column(Name = "VideoSubCategory", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Required(ErrorMessage = "Video Sub Category is required")]
        public string VideoSubCategory { get; set; } // nvarchar(50), not null

        [Column(Name = "ClosedCaptions", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Required(ErrorMessage = "Closed Captions is required")]
        public string ClosedCaptions { get; set; } // nvarchar(50), not null

        [Column(Name = "Language", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Required(ErrorMessage = "Language is required")]
        public string Language { get; set; } // nvarchar(50), not null

        [Column(Name = "RunningTime", TypeName = "smallint")]
        [Required(ErrorMessage = "Running Time is required")]
        public short RunningTime { get; set; } // smallint, not null

        [Column(Name = "VideoMediaType", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Required(ErrorMessage = "Video Media Type is required")]
        public string VideoMediaType { get; set; } // nvarchar(50), not null

        [Column(Name = "VideoEncoding", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Required(ErrorMessage = "Video Encoding is required")]
        public string VideoEncoding { get; set; } // nvarchar(50), not null

        [Column(Name = "ScreenAspect", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Required(ErrorMessage = "Screen Aspect is required")]
        public string ScreenAspect { get; set; } // nvarchar(50), not null

        [Column(Name = "Rating", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Required(ErrorMessage = "Rating is required")]
        public string Rating { get; set; } // nvarchar(50), not null

        [Column(Name = "ProductTitleNumber", TypeName = "int")]
        [Required(ErrorMessage = "Product Title Number is required")]
        public int ProductTitleNumber { get; set; } // int, not null

        // dbo.VideoTitle.ProductNumber -> dbo.Title.ProductNumber (FK_VideoTitle_Title)
        [ForeignKey("ProductNumber")]
        public Title Title { get; set; }
    }
}
