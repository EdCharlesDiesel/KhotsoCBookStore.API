using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB
{
    [Table("Agreement")]
    public class Agreement
    {
        public Agreement()
        {
            this.ActiveMembers = new List<ActiveMember>();
        }

        [Key]
        [Required(ErrorMessage = "Agreement Number is required")]
        public int AgreementNumber { get; set; } 

        [Required(ErrorMessage = "Expiry Date is required")]
        public DateTime ExpiryDate { get; set; } 

        [Required(ErrorMessage = "Active Date is required")]
        public DateTime ActiveDate { get; set; } 

        [Required(ErrorMessage = "Fullfillment Period is required")]
        public byte FullfillmentPeriod { get; set; } 

        [Required(ErrorMessage = "Credits Required is required")]
        public int CreditsRequired { get; set; } 

        // dbo.ActiveMember.AgreementNumber -> dbo.Agreement.AgreementNumber (FK_ActiveMember_Agreement)
        public IEnumerable<ActiveMember> ActiveMembers { get; set; }
    }
}
