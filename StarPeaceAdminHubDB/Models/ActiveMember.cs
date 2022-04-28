namespace StarPeaceAdminHubDB
{
    [Table("ActiveMember")]
    public class ActiveMember
    {
        public ActiveMember()
        {
            this.Transactions = new List<Transaction>();
        }

        [Column(Name = "MemberDateOfLastOrder", TypeName = "smalldatetime")]
        public DateTime? MemberDateOfLastOrder { get; set; } // smalldatetime, null

        [Column(Name = "MemberDaytimePhoneNumber", TypeName = "int")]
        public int? MemberDaytimePhoneNumber { get; set; } // int, null

        [Column(Name = "MemberBalanceDue", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        public string MemberBalanceDue { get; set; } // nvarchar(50), null

        [Column(Name = "MemeberBonusBalanceAvailable", TypeName = "nvarchar")]
        [MaxLength(10)]
        [StringLength(10)]
        public string MemeberBonusBalanceAvailable { get; set; } // nvarchar(10), null

        [Column(Name = "AudioCategoryPreferance", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        public string AudioCategoryPreferance { get; set; } // nvarchar(50), null

        [Column(Name = "VideoCategoryPreference", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        public string VideoCategoryPreference { get; set; } // nvarchar(50), null

        [Column(Name = "BookCategoryPreference", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        public string BookCategoryPreference { get; set; } // nvarchar(50), null

        [Column(Name = "NumberOfCreditsEarned", TypeName = "tinyint")]
        public byte? NumberOfCreditsEarned { get; set; } // tinyint, null

        [Column(Name = "DateEnrolled", TypeName = "smalldatetime")]
        public DateTime? DateEnrolled { get; set; } // smalldatetime, null

        [Column(Name = "PrivacyCode", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        public string PrivacyCode { get; set; } // nvarchar(50), null

        [Column(Name = "MediaPreference", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        public string MediaPreference { get; set; } // nvarchar(50), null

        [Column(Name = "CreditCardExp", TypeName = "smalldatetime")]
        public DateTime? CreditCardExp { get; set; } // smalldatetime, null

        [Column(Name = "CreditCardNumber", TypeName = "nvarchar")]
        [MaxLength(16)]
        [StringLength(16)]
        public string CreditCardNumber { get; set; } // nvarchar(16), null

        [Column(Name = "CreditCardType", TypeName = "nvarchar")]
        [MaxLength(10)]
        [StringLength(10)]
        public string CreditCardType { get; set; } // nvarchar(10), null

        [Column(Name = "ExpirationDate", TypeName = "smalldatetime")]
        public DateTime? ExpirationDate { get; set; } // smalldatetime, null

        [Key]
        [Column(Name = "MemberNumber", TypeName = "int")]
        [Required(ErrorMessage = "Member Number is required")]
        public int MemberNumber { get; set; } // int, not null

        [Column(Name = "MemberLastName", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        public string MemberLastName { get; set; } // nvarchar(50), null

        [Column(Name = "MemberFirstName", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        public string MemberFirstName { get; set; } // nvarchar(50), null

        [Column(Name = "MemberStatus", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        public string MemberStatus { get; set; } // nvarchar(50), null

        [Column(Name = "AgreementNumber", TypeName = "int")]
        public int? AgreementNumber { get; set; } // int, null

        // dbo.ActiveMember.AgreementNumber -> dbo.Agreement.AgreementNumber (FK_ActiveMember_Agreement)
        [ForeignKey("AgreementNumber")]
        public Agreement Agreement { get; set; }

        // dbo.Transaction.MemberNumber -> dbo.ActiveMember.MemberNumber (FK_Transaction_ActiveMember)
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
