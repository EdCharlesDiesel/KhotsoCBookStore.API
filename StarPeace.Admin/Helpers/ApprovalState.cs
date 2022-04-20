using StarPeace.Admin.Contexts;
using StarPeace.Admin.Entities;
using StarPeace.Admin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Admin.Helpers
{
    public class ApprovalState : ICampaignState
    {
          readonly StarPeaceAdminDbContext _dbContext;
        public ApprovalState(StarPeaceAdminDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }
        public void Process(CampaignContext context)
        {

            Campaign campaign = _dbContext.Campaigns.Where(o => o.Id == context.Campaign.Id).SingleOrDefault();
                campaign.Status = "Campaign has been approved";
                _dbContext.SaveChanges();
            
            context.State = new PrepareState();
        }
    }
}
