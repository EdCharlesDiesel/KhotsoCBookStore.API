using StarPeace.Admin.Contexts;
using StarPeace.Admin.Entities;
using StarPeace.Admin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Admin.Helpers
{
    public class AdminObserver:IForumObserver
    {
        readonly StarPeaceAdminDbContext _dbContext;
        public AdminObserver(StarPeaceAdminDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }
        public void Update(ForumPost post)
        {

                Notification notification = new Notification();
                notification.Description = $"New forum post - {post.Title} - received on {DateTime.Now}";
                notification.ReceivedOn = DateTime.Now;
                _dbContext.Notifications.Add(notification);
                _dbContext.SaveChanges();
            
        }
    }
}
