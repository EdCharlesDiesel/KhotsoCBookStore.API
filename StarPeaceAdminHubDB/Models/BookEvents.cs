using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB
{
    [Table("BookEvents")]
    public class BookEvents
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]
        public long Id { get; set; } 

        [Required(ErrorMessage = "Type is required")]
        public int Type { get; set; } 

        [Required(ErrorMessage = "Book Id is required")]
        public int BookId { get; set; } 

        [MaxLength]
        public string Title { get; set; }

        public long? OldVersion { get; set; } 

        public long? NewVersion { get; set; } 
    }
}
