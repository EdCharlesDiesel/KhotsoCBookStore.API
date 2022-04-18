using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StarPeace.Admin.Services;

namespace StarPeace.Admin.Entities
{
    [Table("Shippers")]
    public class Shippers
    {
        public Shippers()
        {
            this.Orders = new List<Orders>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Shipper ID is required")]
        public int ShipperID { get; set; }
        [MaxLength(40)]
        [StringLength(40)]
        [Required(ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }
        [MaxLength(24)]
        [StringLength(24)]
        public string Phone { get; set; }

        // dbo.Orders.ShipVia -> dbo.Shippers.ShipperID (FK_Orders_Shippers)
        public IEnumerable<Orders> Orders { get; set; }
    }
}
