namespace StarPeaceAdminHubDB
{
    [Table("AspNetRoles")]
    public class AspNetRoles
    {
        public AspNetRoles()
        {
            this.AspNetRoleClaims = new List<AspNetRoleClaims>();
            this.AspNetUserRoles = new List<AspNetUserRoles>();
        }

        [Key]
        [Column(Name = "Id", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; } // int, not null

        [Column(Name = "Name", TypeName = "nvarchar")]
        [MaxLength(256)]
        [StringLength(256)]
        public string Name { get; set; } // nvarchar(256), null

        [Column(Name = "NormalizedName", TypeName = "nvarchar")]
        [MaxLength(256)]
        [StringLength(256)]
        public string NormalizedName { get; set; } // nvarchar(256), null

        [Column(Name = "ConcurrencyStamp", TypeName = "nvarchar")]
        [MaxLength]
        public string ConcurrencyStamp { get; set; } // nvarchar(max), null

        // dbo.AspNetRoleClaims.RoleId -> dbo.AspNetRoles.Id (FK_AspNetRoleClaims_AspNetRoles_RoleId)
        public IEnumerable<AspNetRoleClaims> AspNetRoleClaims { get; set; }

        // dbo.AspNetUserRoles.RoleId -> dbo.AspNetRoles.Id (FK_AspNetUserRoles_AspNetRoles_RoleId)
        public IEnumerable<AspNetUserRoles> AspNetUserRoles { get; set; }
    }
}
