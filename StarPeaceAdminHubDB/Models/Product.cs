namespace StarPeaceAdminHubDB
{
    [Table("Product")]
    public class Product
    {
        public Product()
        {
            this.OrderedProducts = new List<OrderedProduct>();
        }

        [Key]
        [Column(Name = "ProductNumber", TypeName = "int")]
        [Required(ErrorMessage = "Product Number is required")]
        public int ProductNumber { get; set; } // int, not null

        [Column(Name = "UPC", TypeName = "nchar")]
        [MaxLength(10)]
        [StringLength(10)]
        [Required(ErrorMessage = "UPC is required")]
        public string UPC { get; set; } // nchar(10), not null

        [Column(Name = "QuantityInStock", TypeName = "smallint")]
        [Required(ErrorMessage = "Quantity In Stock is required")]
        public short QuantityInStock { get; set; } // smallint, not null

        [Column(Name = "ProductType", TypeName = "nvarchar")]
        [MaxLength(10)]
        [StringLength(10)]
        [Required(ErrorMessage = "Product Type is required")]
        public string ProductType { get; set; } // nvarchar(10), not null

        [Column(Name = "SuggestedRetailPrice", TypeName = "money")]
        [Required(ErrorMessage = "Suggested Retail Price is required")]
        public decimal SuggestedRetailPrice { get; set; } // money, not null

        [Column(Name = "DefaultUnitPrice", TypeName = "money")]
        [Required(ErrorMessage = "Default Unit Price is required")]
        public decimal DefaultUnitPrice { get; set; } // money, not null

        [Column(Name = "CurrentSpecialPrice", TypeName = "money")]
        [Required(ErrorMessage = "Current Special Price is required")]
        public decimal CurrentSpecialPrice { get; set; } // money, not null

        [Column(Name = "MonthlyUnitsSold", TypeName = "smallint")]
        [Required(ErrorMessage = "Monthly Units Sold is required")]
        public short MonthlyUnitsSold { get; set; } // smallint, not null

        [Column(Name = "YearlyUnitsSold", TypeName = "int")]
        [Required(ErrorMessage = "Yearly Units Sold is required")]
        public int YearlyUnitsSold { get; set; } // int, not null

        [Column(Name = "TotalUnitsSold", TypeName = "int")]
        [Required(ErrorMessage = "Total Units Sold is required")]
        public int TotalUnitsSold { get; set; } // int, not null

        // dbo.Merchandise.ProductNumber -> dbo.Product.ProductNumber (FK_Merchandise_Product)
        public Merchandise Merchandise { get; set; }

        // dbo.OrderedProduct.ProductNumber -> dbo.Product.ProductNumber (FK_OrderedProduct_Product)
        public IEnumerable<OrderedProduct> OrderedProducts { get; set; }

        // dbo.Title.ProductNumber -> dbo.Product.ProductNumber (FK_Title_Product)
        public Title Title { get; set; }
    }
}
