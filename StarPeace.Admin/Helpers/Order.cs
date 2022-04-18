using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StarPeace.Admin.Helpers
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
