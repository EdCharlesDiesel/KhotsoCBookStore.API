namespace StarPeaceAdminHubDB
{
    [Table("AspNetUsers")]
    public class AspNetUsers
    {
        public AspNetUsers()
        {
            this.AspNetUserClaims = new List<AspNetUserClaims>();
            this.AspNetUserLogins = new List<AspNetUserLogins>();
            this.AspNetUserRoles = new List<AspNetUserRoles>();
            this.AspNetUserTokens = new List<AspNetUserTokens>();
        }

        [Key]
        [Column(Name = "Id", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; } // int, not null

        [Column(Name = "UserName", TypeName = "nvarchar")]
        [MaxLength(256)]
        [StringLength(256)]
        public string UserName { get; set; } // nvarchar(256), null

        [Column(Name = "NormalizedUserName", TypeName = "nvarchar")]
        [MaxLength(256)]
        [StringLength(256)]
        public string NormalizedUserName { get; set; } // nvarchar(256), null

        [Column(Name = "Email", TypeName = "nvarchar")]
        [MaxLength(256)]
        [StringLength(256)]
        public string Email { get; set; } // nvarchar(256), null

        [Column(Name = "NormalizedEmail", TypeName = "nvarchar")]
        [MaxLength(256)]
        [StringLength(256)]
        public string NormalizedEmail { get; set; } // nvarchar(256), null

        [Column(Name = "EmailConfirmed", TypeName = "bit")]
        [Required(ErrorMessage = "Email Confirmed is required")]
        public bool EmailConfirmed { get; set; } // bit, not null

        [Column(Name = "PasswordHash", TypeName = "nvarchar")]
        [MaxLength]
        public string PasswordHash { get; set; } // nvarchar(max), null

        [Column(Name = "SecurityStamp", TypeName = "nvarchar")]
        [MaxLength]
        public string SecurityStamp { get; set; } // nvarchar(max), null

        [Column(Name = "ConcurrencyStamp", TypeName = "nvarchar")]
        [MaxLength]
        public string ConcurrencyStamp { get; set; } // nvarchar(max), null

        [Column(Name = "PhoneNumber", TypeName = "nvarchar")]
        [MaxLength]
        public string PhoneNumber { get; set; } // nvarchar(max), null

        [Column(Name = "PhoneNumberConfirmed", TypeName = "bit")]
        [Required(ErrorMessage = "Phone Number Confirmed is required")]
        public bool PhoneNumberConfirmed { get; set; } // bit, not null

        [Column(Name = "TwoFactorEnabled", TypeName = "bit")]
        [Required(ErrorMessage = "Two Factor Enabled is required")]
        public bool TwoFactorEnabled { get; set; } // bit, not null

        [Column(Name = "LockoutEnd", TypeName = "datetimeoffset")]
        public DateTimeOffset? LockoutEnd { get; set; } // datetimeoffset(7), null

        [Column(Name = "LockoutEnabled", TypeName = "bit")]
        [Required(ErrorMessage = "Lockout Enabled is required")]
        public bool LockoutEnabled { get; set; } // bit, not null

        [Column(Name = "AccessFailedCount", TypeName = "int")]
        [Required(ErrorMessage = "Access Failed Count is required")]
        public int AccessFailedCount { get; set; } // int, not null

        // dbo.AspNetUserClaims.UserId -> dbo.AspNetUsers.Id (FK_AspNetUserClaims_AspNetUsers_UserId)
        public IEnumerable<AspNetUserClaims> AspNetUserClaims { get; set; }

        // dbo.AspNetUserLogins.UserId -> dbo.AspNetUsers.Id (FK_AspNetUserLogins_AspNetUsers_UserId)
        public IEnumerable<AspNetUserLogins> AspNetUserLogins { get; set; }

        // dbo.AspNetUserRoles.UserId -> dbo.AspNetUsers.Id (FK_AspNetUserRoles_AspNetUsers_UserId)
        public IEnumerable<AspNetUserRoles> AspNetUserRoles { get; set; }

        // dbo.AspNetUserTokens.UserId -> dbo.AspNetUsers.Id (FK_AspNetUserTokens_AspNetUsers_UserId)
        public IEnumerable<AspNetUserTokens> AspNetUserTokens { get; set; }
    }
}
