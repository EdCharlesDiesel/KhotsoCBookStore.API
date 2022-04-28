namespace StarPeaceAdminHubDB
{
    [Table("MemberOrder")]
    public class MemberOrder
    {
        public MemberOrder()
        {
            this.Transactions = new List<Transaction>();
        }

        [Key]
        [Column(Name = "OrderNumber", TypeName = "int")]
        [Required(ErrorMessage = "Order Number is required")]
        public int OrderNumber { get; set; } // int, not null

        [Column(Name = "MemberNumber", TypeName = "int")]
        [Required(ErrorMessage = "Member Number is required")]
        public int MemberNumber { get; set; } // int, not null

        [Column(Name = "OrderFillDate", TypeName = "smalldatetime")]
        [Required(ErrorMessage = "Order Fill Date is required")]
        public DateTime OrderFillDate { get; set; } // smalldatetime, not null

        [Column(Name = "OrderCreationDate", TypeName = "smalldatetime")]
        [Required(ErrorMessage = "Order Creation Date is required")]
        public DateTime OrderCreationDate { get; set; } // smalldatetime, not null

        [Column(Name = "OrderShipName", TypeName = "nvarchar")]
        [MaxLength(40)]
        [StringLength(40)]
        [Required(ErrorMessage = "Order Ship Name is required")]
        public string OrderShipName { get; set; } // nvarchar(40), not null

        [Column(Name = "OrderShipAddress", TypeName = "nvarchar")]
        [MaxLength(40)]
        [StringLength(40)]
        [Required(ErrorMessage = "Order Ship Address is required")]
        public string OrderShipAddress { get; set; } // nvarchar(40), not null

        [Column(Name = "OrderShipCity", TypeName = "nvarchar")]
        [MaxLength(30)]
        [StringLength(30)]
        [Required(ErrorMessage = "Order Ship City is required")]
        public string OrderShipCity { get; set; } // nvarchar(30), not null

        [Column(Name = "OrderShipPostalCode", TypeName = "nvarchar")]
        [MaxLength(9)]
        [StringLength(9)]
        [Required(ErrorMessage = "Order Ship Postal Code is required")]
        public string OrderShipPostalCode { get; set; } // nvarchar(9), not null

        [Column(Name = "ShippingInstructions", TypeName = "ntext")]
        [Required(ErrorMessage = "Shipping Instructions is required")]
        public string ShippingInstructions { get; set; } // ntext, not null

        [Column(Name = "OrderSubTotal", TypeName = "money")]
        [Required(ErrorMessage = "Order Sub Total is required")]
        public decimal OrderSubTotal { get; set; } // money, not null

        [Column(Name = "OrderSalesTax", TypeName = "money")]
        [Required(ErrorMessage = "Order Sales Tax is required")]
        public decimal OrderSalesTax { get; set; } // money, not null

        [Column(Name = "OrderShopMethod", TypeName = "nvarchar")]
        [MaxLength(10)]
        [StringLength(10)]
        [Required(ErrorMessage = "Order Shop Method is required")]
        public string OrderShopMethod { get; set; } // nvarchar(10), not null

        [Column(Name = "OrderShippingAndHandlingCosts", TypeName = "money")]
        [Required(ErrorMessage = "Order Shipping And Handling Costs is required")]
        public decimal OrderShippingAndHandlingCosts { get; set; } // money, not null

        [Column(Name = "OrderStatus", TypeName = "nvarchar")]
        [MaxLength(10)]
        [StringLength(10)]
        [Required(ErrorMessage = "Order Status is required")]
        public string OrderStatus { get; set; } // nvarchar(10), not null

        [Column(Name = "OrderPrepaidAmount", TypeName = "money")]
        [Required(ErrorMessage = "Order Prepaid Amount is required")]
        public decimal OrderPrepaidAmount { get; set; } // money, not null

        [Column(Name = "OrderPaymentMethod", TypeName = "nvarchar")]
        [MaxLength(10)]
        [StringLength(10)]
        [Required(ErrorMessage = "Order Payment Method is required")]
        public string OrderPaymentMethod { get; set; } // nvarchar(10), not null

        [Column(Name = "PromotionNumber", TypeName = "int")]
        [Required(ErrorMessage = "Promotion Number is required")]
        public int PromotionNumber { get; set; } // int, not null

        // dbo.MemberOrder.PromotionNumber -> dbo.Promotion.PromotionNumber (FK_MemberOrder_Promotion)
        [ForeignKey("PromotionNumber")]
        public Promotion Promotion { get; set; }

        // dbo.Transaction.OrderNumber -> dbo.MemberOrder.OrderNumber (FK_Transaction_MemberOrder)
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
