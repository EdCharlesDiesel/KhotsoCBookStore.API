using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StarPeaceAdminHubDB.Models
{
    [Table("BookSeriesExtras")]
    public class BookSeriesExtras:  Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BookSeriesExtraId { get; set; }
        
        public bool VideosIncluded { get; set; }
        
        [Required]
        [StringLength(20)]
        public string Notes { get; set; }
    }
}
