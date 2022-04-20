using StarPeace.Admin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarPeace.Admin.Services;

namespace StarPeace.Admin.Helpers
{
    public class Transformer: ISwitchboardItem
    {
        public double Cost { get; set; }

        public double Accept(ISwitchboardVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
