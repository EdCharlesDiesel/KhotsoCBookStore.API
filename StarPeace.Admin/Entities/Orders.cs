using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StarPeace.Admin.Services;

namespace StarPeace.Admin.Entities
{
    [Table("Orders")]
    public class Orders
    {
        public Orders()
        {
            this.OrderDetails = new List<OrderDetails>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Order ID is required")]
        public int OrderID { get; set; }
        [MaxLength(5)]
        [StringLength(5)]
        public string CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        [MaxLength(40)]
        [StringLength(40)]
        public string ShipName { get; set; }
        [MaxLength(60)]
        [StringLength(60)]
        public string ShipAddress { get; set; }
        [MaxLength(15)]
        [StringLength(15)]
        public string ShipCity { get; set; }
        [MaxLength(15)]
        [StringLength(15)]
        public string ShipRegion { get; set; }
        [MaxLength(10)]
        [StringLength(10)]
        public string ShipPostalCode { get; set; }
        [MaxLength(15)]
        [StringLength(15)]
        public string ShipCountry { get; set; }

        // dbo.Orders.CustomerID -> dbo.Customers.CustomerID (FK_Orders_Customers)
        [ForeignKey("CustomerID")]
        public Customers Customer { get; set; }
        // dbo.Orders.EmployeeID -> dbo.Employees.EmployeeID (FK_Orders_Employees)
        //[ForeignKey("EmployeeID")]
        //public Employees Employee { get; set; }
        // dbo.Orders.ShipVia -> dbo.Shippers.ShipperID (FK_Orders_Shippers)
        [ForeignKey("ShipperID")]
        public Shippers ShippedBy { get; set; }
        // dbo.Order Details.OrderID -> dbo.Orders.OrderID (FK_Order_Details_Orders)
        public IEnumerable<OrderDetails> OrderDetails { get; set; }
    }
}
