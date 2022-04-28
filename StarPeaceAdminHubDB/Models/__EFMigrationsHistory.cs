namespace StarPeaceAdminHubDB
{
    [Table("__EFMigrationsHistory")]
    public class __EFMigrationsHistory
    {
        [Key]
        [Column(Name = "MigrationId", TypeName = "nvarchar")]
        [MaxLength(150)]
        [StringLength(150)]
        [Required(ErrorMessage = "Migration Id is required")]
        public string MigrationId { get; set; } // nvarchar(150), not null

        [Column(Name = "ProductVersion", TypeName = "nvarchar")]
        [MaxLength(32)]
        [StringLength(32)]
        [Required(ErrorMessage = "Product Version is required")]
        public string ProductVersion { get; set; } // nvarchar(32), not null
    }
}
