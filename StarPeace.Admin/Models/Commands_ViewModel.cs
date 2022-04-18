using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Admin.Models
{
    public class Commands_ViewModel
    {
        public int EmployeeID { get; set; }
        public DateTime EmailTargetDate { get; set; }
        public DateTime VisitingCardsTargetDate { get; set; }
        public DateTime IdentityCardTargetDate { get; set; }
        public DateTime AccessoriesTargetDate { get; set; }
    }
}
