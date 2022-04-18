using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StarPeace.Admin.Services;

namespace StarPeace.Admin.Entities
{
    [Table("Territories")]
    public class Territories
    {
        public Territories()
        {
            this.Employees = new List<EmployeeTerritories>();
        }

        [Key]
        [MaxLength(20)]
        [StringLength(20)]
        [Required(ErrorMessage = "Territory ID is required")]
        public string TerritoryID { get; set; }
        [MaxLength(50)]
        [StringLength(50)]
        [Required(ErrorMessage = "Territory Description is required")]
        public string TerritoryDescription { get; set; }
        [Required(ErrorMessage = "Region ID is required")]
        public int RegionID { get; set; }

        // dbo.Territories.RegionID -> dbo.Region.RegionID (FK_Territories_Region)
        [ForeignKey("RegionID")]
        public Region Region { get; set; }
        // dbo.Employees.EmployeeID -> dbo.Territories.TerritoryID
        //public IEnumerable<EmployeeTerritories> Employees { get; set; }
    }
}
