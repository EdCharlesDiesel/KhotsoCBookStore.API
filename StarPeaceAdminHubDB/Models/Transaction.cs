using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB
{
    [Table("Transaction")]
    public class Transaction
    {
        [Key]
        [Required(ErrorMessage = "Transaction Reference Number is required")]
        public int TransactionReferenceNumber { get; set; } 

        [Required(ErrorMessage = "Member Number is required")]
        public int MemberNumber { get; set; } 

        [Required(ErrorMessage = "Order Number is required")]
        public int OrderNumber { get; set; } 

        [MaxLength(50)]
        [StringLength(50)]
        [Required(ErrorMessage = "Transaction Type is required")]
        public string TransactionType { get; set; } 

        [MaxLength]
        [Required(ErrorMessage = "Transaction Description is required")]
        public string TransactionDescription { get; set; } 

        [Required(ErrorMessage = "Transaction Amount is required")]
        public decimal TransactionAmount { get; set; } 

        [Required(ErrorMessage = "Transaction Date is required")]
        public DateTime TransactionDate { get; set; } 

        // dbo.Transaction.MemberNumber -> dbo.ActiveMember.MemberNumber (FK_Transaction_ActiveMember)
        [ForeignKey("MemberNumber")]
        public ActiveMember ActiveMember { get; set; }

        // dbo.Transaction.OrderNumber -> dbo.MemberOrder.OrderNumber (FK_Transaction_MemberOrder)
        [ForeignKey("OrderNumber")]
        public MemberOrder MemberOrder { get; set; }
    }
}
