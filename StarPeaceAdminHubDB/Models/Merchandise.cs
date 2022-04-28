using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB
{
    [Table("Merchandise")]
    public class Merchandise
    {
        [Key]
        [Required(ErrorMessage = "Product Number is required")]
        public int ProductNumber { get; set; } 

        [MaxLength(50)]
        [Required(ErrorMessage = "Merchandise Name is required")]
        public string MerchandiseName { get; set; } 

        [Required(ErrorMessage = "Merchandise Description is required")]
        public string MerchandiseDescription { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Merchandise Type is required")]
        public string MerchandiseType { get; set; } 


        [MaxLength(50)]
        [Required(ErrorMessage = "Unit Of Measure is required")]
        public string UnitOfMeasure { get; set; } 

        // dbo.Merchandise.ProductNumber -> dbo.Product.ProductNumber (FK_Merchandise_Product)
        [ForeignKey("ProductNumber")]
        public Product Product { get; set; }
    }
}
