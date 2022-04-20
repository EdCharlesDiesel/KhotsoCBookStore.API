using StarPeace.Admin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Admin.Helpers
{
    public class Enclosure:ISwitchboardItem
    {
        public double Cost { get; set; }

        public double Accept(ISwitchboardVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
