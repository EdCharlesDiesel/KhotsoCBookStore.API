namespace StarPeaceAdminHubDB
{
    [Table("AspNetUserLogins")]
    public class AspNetUserLogins
    {
        [Key]
        [Column(Name = "LoginProvider", TypeName = "nvarchar", Order = 1)]
        [MaxLength(450)]
        [StringLength(450)]
        [Required(ErrorMessage = "Login Provider is required")]
        public string LoginProvider { get; set; } // nvarchar(450), not null

        [Key]
        [Column(Name = "ProviderKey", TypeName = "nvarchar", Order = 2)]
        [MaxLength(450)]
        [StringLength(450)]
        [Required(ErrorMessage = "Provider Key is required")]
        public string ProviderKey { get; set; } // nvarchar(450), not null

        [Column(Name = "ProviderDisplayName", TypeName = "nvarchar")]
        [MaxLength]
        public string ProviderDisplayName { get; set; } // nvarchar(max), null

        [Column(Name = "UserId", TypeName = "int")]
        [Required(ErrorMessage = "User Id is required")]
        public int UserId { get; set; } // int, not null

        // dbo.AspNetUserLogins.UserId -> dbo.AspNetUsers.Id (FK_AspNetUserLogins_AspNetUsers_UserId)
        [ForeignKey("Id")]
        public AspNetUsers AspNetUser { get; set; }
    }
}
