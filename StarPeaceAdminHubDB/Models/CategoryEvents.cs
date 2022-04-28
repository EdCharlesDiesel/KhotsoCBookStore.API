using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB
{
    [Table("CategoryEvents")]
    public class CategoryEvents
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]
        public long Id { get; set; } 

        [Required(ErrorMessage = "Type is required")]
        public int Type { get; set; } 

        [Required(ErrorMessage = "Category Id is required")]
        public int CategoryId { get; set; } 

        [MaxLength]
        public string CategoryName { get; set; }

        public long? OldVersion { get; set; } 

        public long? NewVersion { get; set; } 
    }
}
