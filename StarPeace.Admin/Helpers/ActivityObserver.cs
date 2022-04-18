using StarPeace.Admin.Contexts;
using StarPeace.Admin.Entities;
using StarPeace.Admin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Admin.Helpers
{
    public class ActivityObserver:IForumObserver
    {
        readonly StarPeaceAdminDbContext _dbContext;
        public ActivityObserver(StarPeaceAdminDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        public void Update(ForumPost post)
        {

                Activity activity = new Activity();
                activity.Description = $"User {post.UserName} added a forum post on {DateTime.Now}";
                activity.TimeStamp = DateTime.Now;
                _dbContext.ActivityLogs.Add(activity);
                _dbContext.SaveChanges();
            
        }
    }
}
