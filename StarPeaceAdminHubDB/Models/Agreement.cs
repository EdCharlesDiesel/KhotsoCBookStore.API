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
        [Column(Name = "AgreementNumber", TypeName = "int")]
        [Required(ErrorMessage = "Agreement Number is required")]
        public int AgreementNumber { get; set; } // int, not null

        [Column(Name = "ExpiryDate", TypeName = "smalldatetime")]
        [Required(ErrorMessage = "Expiry Date is required")]
        public DateTime ExpiryDate { get; set; } // smalldatetime, not null

        [Column(Name = "ActiveDate", TypeName = "smalldatetime")]
        [Required(ErrorMessage = "Active Date is required")]
        public DateTime ActiveDate { get; set; } // smalldatetime, not null

        [Column(Name = "FullfillmentPeriod", TypeName = "tinyint")]
        [Required(ErrorMessage = "Fullfillment Period is required")]
        public byte FullfillmentPeriod { get; set; } // tinyint, not null

        [Column(Name = "CreditsRequired", TypeName = "tinyint")]
        [Required(ErrorMessage = "Credits Required is required")]
        public byte CreditsRequired { get; set; } // tinyint, not null

        // dbo.ActiveMember.AgreementNumber -> dbo.Agreement.AgreementNumber (FK_ActiveMember_Agreement)
        public IEnumerable<ActiveMember> ActiveMembers { get; set; }
    }
}
