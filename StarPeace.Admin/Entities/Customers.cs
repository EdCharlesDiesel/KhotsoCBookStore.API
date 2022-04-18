using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StarPeace.Admin.Services;

namespace StarPeace.Admin.Entities
{
    [Table("Customers")]
    public class Customers
    {
        public Customers()
        {
           // this.CustomerDemographics = new List<CustomerCustomerDemo>();
            this.Orders = new List<Orders>();
        }

        [Key]
        [MaxLength(5)]
        [StringLength(5)]
        [Required(ErrorMessage = "Customer ID is required")]
        public string CustomerID { get; set; }
        [MaxLength(40)]
        [StringLength(40)]
        [Required(ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }
        [MaxLength(30)]
        [StringLength(30)]
        public string ContactName { get; set; }
        [MaxLength(30)]
        [StringLength(30)]
        public string ContactTitle { get; set; }
        [MaxLength(60)]
        [StringLength(60)]
        public string Address { get; set; }
        [MaxLength(15)]
        [StringLength(15)]
        public string City { get; set; }
        [MaxLength(15)]
        [StringLength(15)]
        public string Region { get; set; }
        [MaxLength(10)]
        [StringLength(10)]
        public string PostalCode { get; set; }
        [MaxLength(15)]
        [StringLength(15)]
        public string Country { get; set; }
        [MaxLength(24)]
        [StringLength(24)]
        public string Phone { get; set; }
        [MaxLength(24)]
        [StringLength(24)]
        public string Fax { get; set; }

        // dbo.CustomerDemographics.CustomerTypeID -> dbo.Customers.CustomerID
        //public IEnumerable<CustomerCustomerDemo> CustomerDemographics { get; set; }
        // dbo.Orders.CustomerID -> dbo.Customers.CustomerID (FK_Orders_Customers)
        public IEnumerable<Orders> Orders { get; set; }
    }
}
