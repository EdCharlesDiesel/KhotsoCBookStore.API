namespace StarPeaceAdminHubDB
{
    [Table("BookTitle")]
    public class BookTitle
    {
        [Key]
        [Column(Name = "ProductNumber", TypeName = "int")]
        [Required(ErrorMessage = "Product Number is required")]
        public int ProductNumber { get; set; } // int, not null

        [Column(Name = "ISBN", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Required(ErrorMessage = "ISBN is required")]
        public string ISBN { get; set; } // nvarchar(50), not null

        [Column(Name = "PublishedDate", TypeName = "smalldatetime")]
        [Required(ErrorMessage = "Published Date is required")]
        public DateTime PublishedDate { get; set; } // smalldatetime, not null

        [Column(Name = "EntityVersion", TypeName = "int")]
        [Required(ErrorMessage = "Entity Version is required")]
        public int EntityVersion { get; set; } // int, not null

        // dbo.BookTitle.ProductNumber -> dbo.Title.ProductNumber (FK_BookTitle_Title)
        [ForeignKey("ProductNumber")]
        public Title Title { get; set; }
    }
}
