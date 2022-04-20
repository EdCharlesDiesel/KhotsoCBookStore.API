using StarPeace.Admin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Admin.Helpers
{
    public class SpecialVisitor: ISwitchboardVisitor
    {
        public double Visit(Enclosure item)
        {
            return (item.Cost * 1.2);
        }

        public double Visit(Transformer item)
        {
            return (item.Cost * 1.2);
        }

        public double Visit(Busbars item)
        {
            return (item.Cost * 1.2);
        }

        public double Visit(CircuitBreaker item)
        {
            return (item.Cost * 1.2);
        }
    }
}
