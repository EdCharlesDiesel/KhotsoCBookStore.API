using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StarPeace.Admin.Services;

namespace StarPeace.Admin.Entities
{
    [Table("Region")]
    public class Region
    {
        public Region()
        {
            this.Territories = new List<Territories>();
        }

        [Key]
        [Required(ErrorMessage = "Region ID is required")]
        public int RegionID { get; set; }
        [MaxLength(50)]
        [StringLength(50)]
        [Required(ErrorMessage = "Region Description is required")]
        public string RegionDescription { get; set; }

        // dbo.Territories.RegionID -> dbo.Region.RegionID (FK_Territories_Region)
        public IEnumerable<Territories> Territories { get; set; }
    }
}
