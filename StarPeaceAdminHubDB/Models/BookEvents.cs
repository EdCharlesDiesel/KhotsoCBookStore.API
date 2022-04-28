namespace StarPeaceAdminHubDB
{
    [Table("BookEvents")]
    public class BookEvents
    {
        [Key]
        [Column(Name = "Id", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id is required")]
        public long Id { get; set; } // bigint, not null

        [Column(Name = "Type", TypeName = "int")]
        [Required(ErrorMessage = "Type is required")]
        public int Type { get; set; } // int, not null

        [Column(Name = "BookId", TypeName = "int")]
        [Required(ErrorMessage = "Book Id is required")]
        public int BookId { get; set; } // int, not null

        [Column(Name = "Title", TypeName = "nvarchar")]
        [MaxLength]
        public string Title { get; set; } // nvarchar(max), null

        [Column(Name = "OldVersion", TypeName = "bigint")]
        public long? OldVersion { get; set; } // bigint, null

        [Column(Name = "NewVersion", TypeName = "bigint")]
        public long? NewVersion { get; set; } // bigint, null
    }
}
