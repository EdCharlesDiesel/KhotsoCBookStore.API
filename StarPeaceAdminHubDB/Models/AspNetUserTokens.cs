namespace StarPeaceAdminHubDB
{
    [Table("AspNetUserTokens")]
    public class AspNetUserTokens
    {
        [Key]
        [Column(Name = "UserId", TypeName = "int", Order = 1)]
        [Required(ErrorMessage = "User Id is required")]
        public int UserId { get; set; } // int, not null

        [Key]
        [Column(Name = "LoginProvider", TypeName = "nvarchar", Order = 2)]
        [MaxLength(450)]
        [StringLength(450)]
        [Required(ErrorMessage = "Login Provider is required")]
        public string LoginProvider { get; set; } // nvarchar(450), not null

        [Key]
        [Column(Name = "Name", TypeName = "nvarchar", Order = 3)]
        [MaxLength(450)]
        [StringLength(450)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } // nvarchar(450), not null

        [Column(Name = "Value", TypeName = "nvarchar")]
        [MaxLength]
        public string Value { get; set; } // nvarchar(max), null

        // dbo.AspNetUserTokens.UserId -> dbo.AspNetUsers.Id (FK_AspNetUserTokens_AspNetUsers_UserId)
        [ForeignKey("Id")]
        public AspNetUsers AspNetUser { get; set; }
    }
}
