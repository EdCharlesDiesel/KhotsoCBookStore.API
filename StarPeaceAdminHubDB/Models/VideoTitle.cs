using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB
{
    [Table("VideoTitle")]
    public class VideoTitle
    {
        [Key]
        [Required(ErrorMessage = "Product Number is required")]
        public int ProductNumber { get; set; } 

        [MaxLength(50)]
        [Required(ErrorMessage = "Video Producer is required")]
        public string VideoProducer { get; set; } 

        [MaxLength(50)]
        [Required(ErrorMessage = "Video Director is required")]
        public string VideoDirector { get; set; } 

        [MaxLength(50)]
        [Required(ErrorMessage = "Video Category is required")]
        public string VideoCategory { get; set; } 

        [MaxLength(50)]
        [Required(ErrorMessage = "Video Sub Category is required")]
        public string VideoSubCategory { get; set; } 

        [MaxLength(50)]
        [Required(ErrorMessage = "Closed Captions is required")]
        public string ClosedCaptions { get; set; } 

        [MaxLength(50)]
        [Required(ErrorMessage = "Language is required")]
        public string Language { get; set; } 

        [Required(ErrorMessage = "Running Time is required")]
        public short RunningTime { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Video Media Type is required")]
        public string VideoMediaType { get; set; } 

        [MaxLength(50)]
        [Required(ErrorMessage = "Video Encoding is required")]
        public string VideoEncoding { get; set; } 

        [MaxLength(50)]
        [Required(ErrorMessage = "Screen Aspect is required")]
        public string ScreenAspect { get; set; } 

        [MaxLength(50)]
        [Required(ErrorMessage = "Rating is required")]
        public string Rating { get; set; } 

        [Required(ErrorMessage = "Product Title Number is required")]
        public int ProductTitleNumber { get; set; } 

        // dbo.VideoTitle.ProductNumber -> dbo.Title.ProductNumber (FK_VideoTitle_Title)
        [ForeignKey("ProductNumber")]
        public Title Title { get; set; }
    }
}
