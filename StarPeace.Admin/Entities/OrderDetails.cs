using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StarPeace.Admin.Services;

namespace StarPeace.Admin.Entities
{
    [Table("Order Details")]
    public class OrderDetails
    {
        [Key]
        [Column(Order = 1)]
        [Required(ErrorMessage = "Order ID is required")]
        public int OrderID { get; set; }
        [Key]
        [Column(Order = 2)]
        [Required(ErrorMessage = "Product ID is required")]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Unit Price is required")]
        public decimal UnitPrice { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        public short Quantity { get; set; }
        [Required(ErrorMessage = "Discount is required")]
        public Single Discount { get; set; }

        // dbo.Order Details.OrderID -> dbo.Orders.OrderID (FK_Order_Details_Orders)
        [ForeignKey("OrderID")]
        public Orders Order { get; set; }
        // dbo.Order Details.ProductID -> dbo.Products.ProductID (FK_Order_Details_Products)
        [ForeignKey("ProductID")]
        public Products Product { get; set; }
    }
}
