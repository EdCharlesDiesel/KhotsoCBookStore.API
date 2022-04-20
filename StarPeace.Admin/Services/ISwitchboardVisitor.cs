using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarPeace.Admin.Helpers;

namespace StarPeace.Admin.Services
{
    public interface ISwitchboardVisitor
    {
        double Visit(Enclosure item);
        double Visit(Busbars item);
        double Visit(CircuitBreaker item);
        double Visit(Transformer item);
    }
}
