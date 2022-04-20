using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StarPeace.Admin.Services;

namespace StarPeace.Admin.Entities
{
    [Table("Categories")]
    public class Categories
    {
        public Categories()
        {
            this.Products = new List<Products>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Category ID is required")]
        public int CategoryID { get; set; }
        [MaxLength(15)]
        [StringLength(15)]
        [Required(ErrorMessage = "Category Name is required")]
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        // dbo.Products.CategoryID -> dbo.Categories.CategoryID (FK_Products_Categories)
        public IEnumerable<Products> Products { get; set; }
    }
}
