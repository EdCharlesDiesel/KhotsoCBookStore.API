namespace StarPeaceAdminHubDB
{
    [Table("Transaction")]
    public class Transaction
    {
        [Key]
        [Column(Name = "TransactionReferenceNumber", TypeName = "int")]
        [Required(ErrorMessage = "Transaction Reference Number is required")]
        public int TransactionReferenceNumber { get; set; } // int, not null

        [Column(Name = "MemberNumber", TypeName = "int")]
        [Required(ErrorMessage = "Member Number is required")]
        public int MemberNumber { get; set; } // int, not null

        [Column(Name = "OrderNumber", TypeName = "int")]
        [Required(ErrorMessage = "Order Number is required")]
        public int OrderNumber { get; set; } // int, not null

        [Column(Name = "TransactionType", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Required(ErrorMessage = "Transaction Type is required")]
        public string TransactionType { get; set; } // nvarchar(50), not null

        [Column(Name = "TransactionDescription", TypeName = "nvarchar")]
        [MaxLength]
        [Required(ErrorMessage = "Transaction Description is required")]
        public string TransactionDescription { get; set; } // nvarchar(max), not null

        [Column(Name = "TransactionAmount", TypeName = "money")]
        [Required(ErrorMessage = "Transaction Amount is required")]
        public decimal TransactionAmount { get; set; } // money, not null

        [Column(Name = "TransactionDate", TypeName = "smalldatetime")]
        [Required(ErrorMessage = "Transaction Date is required")]
        public DateTime TransactionDate { get; set; } // smalldatetime, not null

        // dbo.Transaction.MemberNumber -> dbo.ActiveMember.MemberNumber (FK_Transaction_ActiveMember)
        [ForeignKey("MemberNumber")]
        public ActiveMember ActiveMember { get; set; }

        // dbo.Transaction.OrderNumber -> dbo.MemberOrder.OrderNumber (FK_Transaction_MemberOrder)
        [ForeignKey("OrderNumber")]
        public MemberOrder MemberOrder { get; set; }
    }
}
