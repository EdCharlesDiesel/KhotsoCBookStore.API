using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB
{
    [Table("OrderedProduct")]
    public class OrderedProduct
    {
        [Key]
        [Required(ErrorMessage = "Order Number is required")]
        public int OrderNumber { get; set; } 

        [Required(ErrorMessage = "Product Number is required")]
        public int ProductNumber { get; set; } 

        [Required(ErrorMessage = "Quantity Ordered is required")]
        public short QuantityOrdered { get; set; } 

        [Required(ErrorMessage = "Quantity Shipped is required")]
        public short QuantityShipped { get; set; } 

        [Required(ErrorMessage = "Quantity Back Ordered is required")]
        public short QuantityBackOrdered { get; set; } 

        [Required(ErrorMessage = "Unit Price is required")]
        public decimal UnitPrice { get; set; } 

        [Required(ErrorMessage = "Credits Earned is required")]
        public short CreditsEarned { get; set; } 

        [Required(ErrorMessage = "Member Number is required")]
        public int MemberNumber { get; set; } 

        // dbo.OrderedProduct.ProductNumber -> dbo.Product.ProductNumber (FK_OrderedProduct_Product)
        [ForeignKey("ProductNumber")]
        public Product Product { get; set; }
    }
}
