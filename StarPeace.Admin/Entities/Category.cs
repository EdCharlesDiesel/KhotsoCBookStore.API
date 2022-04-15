using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarPeace.Admin.Entities
{
    [Table("Categories")]
    public class Category
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CategoryID { get; set; }
        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
        [Required]
        [StringLength(50)]
        public string AdminEmail { get; set; }
        [Required]
        public bool LogErrors { get; set; }
        
    }
}