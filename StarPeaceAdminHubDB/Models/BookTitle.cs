using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB
{
    [Table("BookTitle")]
    public class BookTitle
    {
        [Key]
        [Required(ErrorMessage = "Product Number is required")]
        public int ProductNumber { get; set; } 

        [MaxLength(50)]
        [Required(ErrorMessage = "ISBN is required")]
        public string ISBN { get; set; } 

        [Required(ErrorMessage = "Published Date is required")]
        public DateTime PublishedDate { get; set; } 

        [Required(ErrorMessage = "Entity Version is required")]
        public int EntityVersion { get; set; } 

        // dbo.BookTitle.ProductNumber -> dbo.Title.ProductNumber (FK_BookTitle_Title)
        [ForeignKey("ProductNumber")]
        public Title Title { get; set; }
    }
}
