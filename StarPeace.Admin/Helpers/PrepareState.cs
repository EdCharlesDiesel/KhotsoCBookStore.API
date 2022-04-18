using StarPeace.Admin.Contexts;
using StarPeace.Admin.Entities;
using StarPeace.Admin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Admin.Helpers
{
    public class PrepareState : ICampaignState
    {
        readonly StarPeaceAdminDbContext _dbContext;
        public PrepareState(StarPeaceAdminDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        public void Process(CampaignContext context)
        {
            Campaign campaign = _dbContext.Campaigns.Where(o => o.Id == context.Campaign.Id).SingleOrDefault();
            campaign.Status = "Material for the campaign has been ordered";
            _dbContext.SaveChanges();
            
            context.State = new RunState();
        }
    }
}
