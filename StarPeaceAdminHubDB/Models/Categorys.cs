using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB
{
    [Table("Categorys")]
    public class Categorys
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; } 

        [MaxLength(128)]
        [Required(ErrorMessage = "Category Name is required")]
        public string CategoryName { get; set; } 

        [Required(ErrorMessage = "Entity Version is required")]
        public long EntityVersion { get; set; } 

        [Required(ErrorMessage = "Book Id is required")]
        public int BookId { get; set; }

        // dbo.Categorys.BookId -> dbo.Books.Id (FK_Categorys_Books_BookId)
        [ForeignKey("Id")]
        public Books Book { get; set; }
    }
}
