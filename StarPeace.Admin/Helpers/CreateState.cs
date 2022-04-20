using StarPeace.Admin.Contexts;
using StarPeace.Admin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Admin.Helpers
{
    public class CreateState : ICampaignState
    {
        readonly StarPeaceAdminDbContext _dbContext;
        public CreateState(StarPeaceAdminDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }
        public void Process(CampaignContext context)
        {
            context.Campaign.Status = "Campaign has been created";
            _dbContext.Campaigns.Add(context.Campaign);
            _dbContext.SaveChanges();
            
            context.State = new ApprovalState();
        }
    }
}
