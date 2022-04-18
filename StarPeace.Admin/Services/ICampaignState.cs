using StarPeace.Admin.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Admin.Services
{
    public interface ICampaignState
    {
        void Process(CampaignContext context);
    }
}
