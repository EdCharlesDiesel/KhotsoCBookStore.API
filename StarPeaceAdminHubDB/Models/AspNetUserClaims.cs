namespace StarPeaceAdminHubDB
{
    [Table("AspNetUserClaims")]
    public class AspNetUserClaims
    {
        [Key]
        [Column(Name = "Id", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; } // int, not null

        [Column(Name = "UserId", TypeName = "int")]
        [Required(ErrorMessage = "User Id is required")]
        public int UserId { get; set; } // int, not null

        [Column(Name = "ClaimType", TypeName = "nvarchar")]
        [MaxLength]
        public string ClaimType { get; set; } // nvarchar(max), null

        [Column(Name = "ClaimValue", TypeName = "nvarchar")]
        [MaxLength]
        public string ClaimValue { get; set; } // nvarchar(max), null

        // dbo.AspNetUserClaims.UserId -> dbo.AspNetUsers.Id (FK_AspNetUserClaims_AspNetUsers_UserId)
        [ForeignKey("Id")]
        public AspNetUsers AspNetUser { get; set; }
    }
}
