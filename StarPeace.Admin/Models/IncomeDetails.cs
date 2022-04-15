using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Admin.Models
{
    public class IncomeDetails
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalDeduction { get; set; }
        public string Country { get; set; }
    }
}
