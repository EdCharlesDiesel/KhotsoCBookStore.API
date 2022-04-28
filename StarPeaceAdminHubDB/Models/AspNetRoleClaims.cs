namespace StarPeaceAdminHubDB
{
    [Table("AspNetRoleClaims")]
    public class AspNetRoleClaims
    {
        [Key]
        [Column(Name = "Id", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; } // int, not null

        [Column(Name = "RoleId", TypeName = "int")]
        [Required(ErrorMessage = "Role Id is required")]
        public int RoleId { get; set; } // int, not null

        [Column(Name = "ClaimType", TypeName = "nvarchar")]
        [MaxLength]
        public string ClaimType { get; set; } // nvarchar(max), null

        [Column(Name = "ClaimValue", TypeName = "nvarchar")]
        [MaxLength]
        public string ClaimValue { get; set; } // nvarchar(max), null

        // dbo.AspNetRoleClaims.RoleId -> dbo.AspNetRoles.Id (FK_AspNetRoleClaims_AspNetRoles_RoleId)
        [ForeignKey("Id")]
        public AspNetRoles AspNetRole { get; set; }
    }
}
