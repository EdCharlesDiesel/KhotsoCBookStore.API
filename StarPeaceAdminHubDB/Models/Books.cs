namespace StarPeaceAdminHubDB
{
    [Table("Books")]
    public class Books
    {
        public Books()
        {
            this.Categorys = new List<Categorys>();
        }

        [Key]
        [Column(Name = "Id", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; } // int, not null

        [Column(Name = "Title", TypeName = "nvarchar")]
        [MaxLength(128)]
        [StringLength(128)]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } // nvarchar(128), not null

        [Column(Name = "ISBN", TypeName = "nvarchar")]
        [MaxLength(128)]
        [StringLength(128)]
        [Required(ErrorMessage = "ISBN is required")]
        public string ISBN { get; set; } // nvarchar(128), not null

        [Column(Name = "PublishingDate", TypeName = "datetime2")]
        [Required(ErrorMessage = "Publishing Date is required")]
        public DateTime PublishingDate { get; set; } // datetime2(7), not null

        [Column(Name = "Cost", TypeName = "decimal")]
        [Required(ErrorMessage = "Cost is required")]
        public decimal Cost { get; set; } // decimal(18,2), not null

        [Column(Name = "RetailPrice", TypeName = "decimal")]
        [Required(ErrorMessage = "Retail Price is required")]
        public decimal RetailPrice { get; set; } // decimal(18,2), not null

        [Column(Name = "CoverFileName", TypeName = "nvarchar")]
        [MaxLength]
        public string CoverFileName { get; set; } // nvarchar(max), null

        [Column(Name = "EntityVersion", TypeName = "bigint")]
        [Required(ErrorMessage = "Entity Version is required")]
        public long EntityVersion { get; set; } // bigint, not null

        // dbo.Categorys.BookId -> dbo.Books.Id (FK_Categorys_Books_BookId)
        public IEnumerable<Categorys> Categorys { get; set; }
    }
}
