using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB
{

    public class ActiveMember
    {
        public ActiveMember()
        {
            this.Transactions = new List<Transaction>();
        }
        
        [Key]
        [Required(ErrorMessage = "Member Number is required")]
        public int MemberNumber { get; set; }
      
        public DateTime MemberDateOfLastOrder { get; set; } 

        public int MemberDaytimePhoneNumber { get; set; } 

        [MaxLength(50)]       
        public string MemberBalanceDue { get; set; } 

        [MaxLength(10)]      
        public string MemeberBonusBalanceAvailable { get; set; } 

        [MaxLength(50)]       
        public string AudioCategoryPreferance { get; set; } 

        [MaxLength(50)]       
        public string VideoCategoryPreference { get; set; } 

        [MaxLength(50)]       
        public string BookCategoryPreference { get; set; } 

        public int NumberOfCreditsEarned { get; set; } 

        public DateTime DateEnrolled { get; set; } 

        [MaxLength(50)]       
        public string PrivacyCode { get; set; } 


        [MaxLength(50)]       
        public string MediaPreference { get; set; } 

        public DateTime CreditCardExp { get; set; } 

        [MaxLength(16)]
        public string CreditCardNumber { get; set; }

        [MaxLength(10)]      
        public string CreditCardType { get; set; } 

        public DateTime? ExpirationDate { get; set; } 
      

        [MaxLength(50)]       
        public string MemberLastName { get; set; } 

        [MaxLength(50)]       
        public string MemberFirstName { get; set; } 

        [MaxLength(50)]       
        public string MemberStatus { get; set; } 

        public int AgreementNumber { get; set; } 

        // dbo.ActiveMember.AgreementNumber -> dbo.Agreement.AgreementNumber (FK_ActiveMember_Agreement)
        [ForeignKey("AgreementNumber")]
        public Agreement Agreement { get; set; }

        // dbo.Transaction.MemberNumber -> dbo.ActiveMember.MemberNumber (FK_Transaction_ActiveMember)
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
