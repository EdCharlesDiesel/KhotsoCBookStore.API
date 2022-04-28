namespace StarPeaceAdminHubDB
{
    [Table("AudioTitle")]
    public class AudioTitle
    {
        [Key]
        [Column(Name = "ProductNumber", TypeName = "int")]
        [Required(ErrorMessage = "Product Number is required")]
        public int ProductNumber { get; set; } // int, not null

        [Column(Name = "Artist", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Required(ErrorMessage = "Artist is required")]
        public string Artist { get; set; } // nvarchar(50), not null

        [Column(Name = "Category", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; } // nvarchar(50), not null

        [Column(Name = "SubCategory", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Required(ErrorMessage = "Sub Category is required")]
        public string SubCategory { get; set; } // nvarchar(50), not null

        [Column(Name = "Units", TypeName = "tinyint")]
        [Required(ErrorMessage = "Units is required")]
        public byte Units { get; set; } // tinyint, not null

        [Column(Name = "MediaType", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Required(ErrorMessage = "Media Type is required")]
        public string MediaType { get; set; } // nvarchar(50), not null

        [Column(Name = "AdvisoryCode", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Required(ErrorMessage = "Advisory Code is required")]
        public string AdvisoryCode { get; set; } // nvarchar(50), not null

        [Column(Name = "ProductTitleNumber", TypeName = "int")]
        [Required(ErrorMessage = "Product Title Number is required")]
        public int ProductTitleNumber { get; set; } // int, not null

        // dbo.AudioTitle.ProductNumber -> dbo.Title.ProductNumber (FK_AudioTitle_Title)
        [ForeignKey("ProductNumber")]
        public Title Title { get; set; }
    }
}
