namespace StarPeaceAdminHubDB
{
    [Table("OrderedProduct")]
    public class OrderedProduct
    {
        [Key]
        [Column(Name = "OrderNumber", TypeName = "int")]
        [Required(ErrorMessage = "Order Number is required")]
        public int OrderNumber { get; set; } // int, not null

        [Column(Name = "ProductNumber", TypeName = "int")]
        [Required(ErrorMessage = "Product Number is required")]
        public int ProductNumber { get; set; } // int, not null

        [Column(Name = "QuantityOrdered", TypeName = "smallint")]
        [Required(ErrorMessage = "Quantity Ordered is required")]
        public short QuantityOrdered { get; set; } // smallint, not null

        [Column(Name = "QuantityShipped", TypeName = "smallint")]
        [Required(ErrorMessage = "Quantity Shipped is required")]
        public short QuantityShipped { get; set; } // smallint, not null

        [Column(Name = "QuantityBackOrdered", TypeName = "smallint")]
        [Required(ErrorMessage = "Quantity Back Ordered is required")]
        public short QuantityBackOrdered { get; set; } // smallint, not null

        [Column(Name = "UnitPrice", TypeName = "money")]
        [Required(ErrorMessage = "Unit Price is required")]
        public decimal UnitPrice { get; set; } // money, not null

        [Column(Name = "CreditsEarned", TypeName = "smallint")]
        [Required(ErrorMessage = "Credits Earned is required")]
        public short CreditsEarned { get; set; } // smallint, not null

        [Column(Name = "MemberNumber", TypeName = "int")]
        [Required(ErrorMessage = "Member Number is required")]
        public int MemberNumber { get; set; } // int, not null

        // dbo.OrderedProduct.ProductNumber -> dbo.Product.ProductNumber (FK_OrderedProduct_Product)
        [ForeignKey("ProductNumber")]
        public Product Product { get; set; }
    }
}
