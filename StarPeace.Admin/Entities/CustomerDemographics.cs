using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StarPeace.Admin.Services;

namespace StarPeace.Admin.Entities
{
    [Table("CustomerDemographics")]
    public class CustomerDemographics
    {
        public CustomerDemographics()
        {
           // this.Customers = new List<CustomerCustomerDemo>();
        }

        [Key]
        [MaxLength(10)]
        [StringLength(10)]
        [Required(ErrorMessage = "Customer Type ID is required")]
        public string CustomerTypeID { get; set; }
        public string CustomerDesc { get; set; }

        // dbo.Customers.CustomerID -> dbo.CustomerDemographics.CustomerTypeID
        //public IEnumerable<CustomerCustomerDemo> Customers { get; set; }
    }
}
