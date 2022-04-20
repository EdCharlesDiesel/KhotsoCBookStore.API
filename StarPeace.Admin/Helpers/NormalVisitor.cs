using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarPeace.Admin.Services;

namespace StarPeace.Admin.Helpers
{
    public class NormalVisitor: ISwitchboardVisitor
    {
        public double Visit(Enclosure item)
        {
            return (item.Cost * 1.1);
        }

        public double Visit(Transformer item)
        {
            return (item.Cost * 1.1);
        }

        public double Visit(Busbars item)
        {
            return (item.Cost * 1.1);
        }

        public double Visit(CircuitBreaker item)
        {
            return (item.Cost * 1.1);
        }
    }
}
