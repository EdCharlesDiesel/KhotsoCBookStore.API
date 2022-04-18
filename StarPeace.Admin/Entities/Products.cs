using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StarPeace.Admin.Services;

namespace StarPeace.Admin.Entities
{
    [Table("Products")]
    public class Products
    {
        public Products()
        {
            this.OrderDetails = new List<OrderDetails>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Product ID is required")]
        public int ProductID { get; set; }
        [MaxLength(40)]
        [StringLength(40)]
        [Required(ErrorMessage = "Product Name is required")]
        public string ProductName { get; set; }
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        [MaxLength(20)]
        [StringLength(20)]
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        [Required(ErrorMessage = "Discontinued is required")]
        public bool Discontinued { get; set; }

        // dbo.Products.SupplierID -> dbo.Suppliers.SupplierID (FK_Products_Suppliers)
        [ForeignKey("SupplierID")]
        public Suppliers Supplier { get; set; }
        // dbo.Products.CategoryID -> dbo.Categories.CategoryID (FK_Products_Categories)
        [ForeignKey("CategoryID")]
        public Categories Category { get; set; }
        // dbo.Order Details.ProductID -> dbo.Products.ProductID (FK_Order_Details_Products)
        public IEnumerable<OrderDetails> OrderDetails { get; set; }
    }
}
