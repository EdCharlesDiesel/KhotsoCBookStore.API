using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StarPeace.Admin.Helpers
{
    public class BuySellDetails
    {
        public string UserName { get; set; }
        public string Symbol { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
