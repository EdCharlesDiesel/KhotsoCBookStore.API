namespace StarPeaceAdminHubDB
{
    [Table("Categorys")]
    public class Categorys
    {
        [Key]
        [Column(Name = "Id", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; } // int, not null

        [Column(Name = "CategoryName", TypeName = "nvarchar")]
        [MaxLength(128)]
        [StringLength(128)]
        [Required(ErrorMessage = "Category Name is required")]
        public string CategoryName { get; set; } // nvarchar(128), not null

        [Column(Name = "EntityVersion", TypeName = "bigint")]
        [Required(ErrorMessage = "Entity Version is required")]
        public long EntityVersion { get; set; } // bigint, not null

        [Column(Name = "BookId", TypeName = "int")]
        [Required(ErrorMessage = "Book Id is required")]
        public int BookId { get; set; } // int, not null

        // dbo.Categorys.BookId -> dbo.Books.Id (FK_Categorys_Books_BookId)
        [ForeignKey("Id")]
        public Books Book { get; set; }
    }
}
