using StarPeace.Admin.Entities;
using StarPeace.Admin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Admin.Contexts
{
    public class CampaignContext
    {
        public ICampaignState State { get; set; }
        public Campaign Campaign { get; set; }

        public CampaignContext(ICampaignState state)
        {
            this.State = state;
        }

        public void Process()
        {
            State.Process(this);
        }
    }
}
