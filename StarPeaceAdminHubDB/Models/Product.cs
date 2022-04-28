using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Required(ErrorMessage = "Product Number is required")]
        public int ProductNumber { get; set; } 

        [MaxLength(10)]
        [Required(ErrorMessage = "UPC is required")]
        public string UPC { get; set; } 

        [Required(ErrorMessage = "Quantity In Stock is required")]
        public short QuantityInStock { get; set; } 

        [MaxLength(10)]
        [Required(ErrorMessage = "Product Type is required")]
        public string ProductType { get; set; } 

        [Required(ErrorMessage = "Suggested Retail Price is required")]
        public decimal SuggestedRetailPrice { get; set; } 

        [Required(ErrorMessage = "Default Unit Price is required")]
        public decimal DefaultUnitPrice { get; set; } 

        [Required(ErrorMessage = "Current Special Price is required")]
        public decimal CurrentSpecialPrice { get; set; } 

        [Required(ErrorMessage = "Monthly Units Sold is required")]
        public short MonthlyUnitsSold { get; set; } 

        [Required(ErrorMessage = "Yearly Units Sold is required")]
        public int YearlyUnitsSold { get; set; } 

        [Required(ErrorMessage = "Total Units Sold is required")]
        public int TotalUnitsSold { get; set; } 

        // dbo.Merchandise.ProductNumber -> dbo.Product.ProductNumber (FK_Merchandise_Product)
        public Merchandise Merchandise { get; set; }

        // dbo.OrderedProduct.ProductNumber -> dbo.Product.ProductNumber (FK_OrderedProduct_Product)
        public IEnumerable<OrderedProduct> OrderedProducts { get; set; }

        // dbo.Title.ProductNumber -> dbo.Product.ProductNumber (FK_Title_Product)
        public Title Title { get; set; }
    }
}
