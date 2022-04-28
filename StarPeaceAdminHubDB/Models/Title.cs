using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB
{
    [Table("Title")]
    public class Title
    {
        public Title()
        {
            this.TitlePromotions = new List<TitlePromotion>();
        }

        [Key]
        [Required(ErrorMessage = "Product Number is required")]
        public int ProductNumber { get; set; } 

        [MaxLength(50)]
        [Required(ErrorMessage = "Title Of book is required")]
        public string TitleBook { get; set; } 

        [Required(ErrorMessage = "Title Cover is required")]
        public byte[] TitleCover { get; set; } 

        [MaxLength]
        [Required(ErrorMessage = "Catelog Description is required")]
        public string CatelogDescription { get; set; } 

        [Required(ErrorMessage = "Copy Right Date is required")]
        public DateTime CopyRightDate { get; set; } 

        [MaxLength(50)]
        [Required(ErrorMessage = "Title Category is required")]
        public string TitleCategory { get; set; } 

        [Required(ErrorMessage = "Credit Value is required")]
        public short CreditValue { get; set; } 

        // dbo.Title.ProductNumber -> dbo.Product.ProductNumber (FK_Title_Product)
        [ForeignKey("ProductNumber")]
        public Product Product { get; set; }

        // dbo.AudioTitle.ProductNumber -> dbo.Title.ProductNumber (FK_AudioTitle_Title)
        public AudioTitle AudioTitle { get; set; }

        // dbo.BookTitle.ProductNumber -> dbo.Title.ProductNumber (FK_BookTitle_Title)
        public BookTitle BookTitle { get; set; }

        // dbo.TitlePromotion.ProductNumber -> dbo.Title.ProductNumber (FK_TitlePromotion_Title)
        public IEnumerable<TitlePromotion> TitlePromotions { get; set; }

        // dbo.VideoTitle.ProductNumber -> dbo.Title.ProductNumber (FK_VideoTitle_Title)
        public VideoTitle VideoTitle { get; set; }
    }
}
