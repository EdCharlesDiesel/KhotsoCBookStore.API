using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB
{
    [Table("Books")]
    public class Books
    {
        public Books()
        {
            this.Categorys = new List<Categorys>();
        }

        [Key]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; } 

        [MaxLength(128)]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } 

        [MaxLength(128)]

        [Required(ErrorMessage = "ISBN is required")]
        public string ISBN { get; set; } 

        [Required(ErrorMessage = "Publishing Date is required")]
        public DateTime PublishingDate { get; set; } 

        [Required(ErrorMessage = "Cost is required")]
        public decimal Cost { get; set; } 

        [Required(ErrorMessage = "Retail Price is required")]
        public decimal RetailPrice { get; set; } 

        [MaxLength]
        public string CoverFileName { get; set; }

        [Required(ErrorMessage = "Entity Version is required")]
        public long EntityVersion { get; set; }

        // dbo.Categorys.BookId -> dbo.Books.Id (FK_Categorys_Books_BookId)
        public IEnumerable<Categorys> Categorys { get; set; }
    }
}
