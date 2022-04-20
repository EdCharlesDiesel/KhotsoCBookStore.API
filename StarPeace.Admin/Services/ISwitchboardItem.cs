using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Admin.Services
{
    public interface ISwitchboardItem
    {
        double Accept(ISwitchboardVisitor visitor);
    }
}
