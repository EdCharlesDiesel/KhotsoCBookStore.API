using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace StarPeace.Admin.Entities
{
    [Table("BookSeriesBooks")]
    public class BookSeriesBook
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Category { get; set; }
        [Required]
        [StringLength(20)]
        public string Book { get; set; }
        [Required]
        [StringLength(50)]
        public string BookISBN { get; set; }
    }
}
