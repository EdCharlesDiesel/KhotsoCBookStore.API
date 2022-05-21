using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB
{
    public class AudioTitle
    {
        [Key]
        [Required(ErrorMessage = "Product Number is required")]
        public int ProductNumber { get; set; } // int, not null

        [MaxLength(50)]
        [Required(ErrorMessage = "Artist is required")]
        public string Artist { get; set; } 

        [MaxLength(50)]
        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; } 

        [MaxLength(50)]
        [Required(ErrorMessage = "Sub Category is required")]
        public string SubCategory { get; set; } 

        [Required(ErrorMessage = "Units is required")]
        public byte Units { get; set; } 

        [MaxLength(50)]
        [Required(ErrorMessage = "Media Type is required")]
        public string MediaType { get; set; } 

        [MaxLength(50)]
        [Required(ErrorMessage = "Advisory Code is required")]
        public string AdvisoryCode { get; set; } 

        [Required(ErrorMessage = "Product Title Number is required")]
        public int ProductTitleNumber { get; set; }

        // dbo.AudioTitle.ProductNumber -> dbo.Title.ProductNumber (FK_AudioTitle_Title)
        [ForeignKey("ProductNumber")]
        public Title Title { get; set; }
    }
}
