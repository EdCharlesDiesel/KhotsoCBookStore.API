namespace StarPeaceAdminHubDB
{
    [Table("Merchandise")]
    public class Merchandise
    {
        [Key]
        [Column(Name = "ProductNumber", TypeName = "int")]
        [Required(ErrorMessage = "Product Number is required")]
        public int ProductNumber { get; set; } // int, not null

        [Column(Name = "MerchandiseName", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Required(ErrorMessage = "Merchandise Name is required")]
        public string MerchandiseName { get; set; } // nvarchar(50), not null

        [Column(Name = "MerchandiseDescription", TypeName = "ntext")]
        [Required(ErrorMessage = "Merchandise Description is required")]
        public string MerchandiseDescription { get; set; } // ntext, not null

        [Column(Name = "MerchandiseType", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Required(ErrorMessage = "Merchandise Type is required")]
        public string MerchandiseType { get; set; } // nvarchar(50), not null

        [Column(Name = "UnitOfMeasure", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Required(ErrorMessage = "Unit Of Measure is required")]
        public string UnitOfMeasure { get; set; } // nvarchar(50), not null

        // dbo.Merchandise.ProductNumber -> dbo.Product.ProductNumber (FK_Merchandise_Product)
        [ForeignKey("ProductNumber")]
        public Product Product { get; set; }
    }
}
