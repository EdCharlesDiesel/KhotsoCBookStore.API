namespace StarPeaceAdminHubDB
{
    [Table("AspNetUserRoles")]
    public class AspNetUserRoles
    {
        [Key]
        [Column(Name = "UserId", TypeName = "int", Order = 1)]
        [Required(ErrorMessage = "User Id is required")]
        public int UserId { get; set; } // int, not null

        [Key]
        [Column(Name = "RoleId", TypeName = "int", Order = 2)]
        [Required(ErrorMessage = "Role Id is required")]
        public int RoleId { get; set; } // int, not null

        // dbo.AspNetUserRoles.UserId -> dbo.AspNetUsers.Id (FK_AspNetUserRoles_AspNetUsers_UserId)
        [ForeignKey("Id")]
        public AspNetUsers AspNetUser { get; set; }

        // dbo.AspNetUserRoles.RoleId -> dbo.AspNetRoles.Id (FK_AspNetUserRoles_AspNetRoles_RoleId)
        [ForeignKey("Id")]
        public AspNetRoles AspNetRole { get; set; }
    }
}
