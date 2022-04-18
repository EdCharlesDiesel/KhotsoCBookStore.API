using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System.IO;
using Microsoft.Extensions.Caching.Memory;
using StarPeace.Admin.Helpers;
using StarPeace.Admin.Contexts;
using StarPeace.Admin.Entities;

namespace StarPeace.Admin.Controllers
{
    public class HomeController : Controller
    {
        IMemoryCache cache;
        readonly StarPeaceAdminDbContext _dbContext;

        public HomeController(IMemoryCache cache,StarPeaceAdminDbContext dbContext)
        {
            this.cache = cache;
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        public IActionResult Index()
        {
            AdminObserver observer1 = new AdminObserver();
            ActivityObserver observer2 = new ActivityObserver();
            ForumNotifier notifier = new ForumNotifier();

            notifier.Subscribe(observer1);
            notifier.Subscribe(observer2);

            //cache.Set("notifier", notifier);

            return View();
        }

        public IActionResult AddPost(ForumPost post)
        {
            post.PostedOn = DateTime.Now;
            _dbContext.ForumPosts.Add(post);
            _dbContext.SaveChanges();
            
            ViewBag.Message = "Post submitted successfully!";
            //ForumNotifier notifier = cache.Get<ForumNotifier>("notifier");
            ForumNotifier notifier = new ForumNotifier();
            notifier.Notify(post);
            return View("Index", post);
        }

        public IActionResult ShowNotifications()
        {
            List<Notification> notifications = _dbContext.Notifications.ToList();
            return View(notifications);            
        }

        public IActionResult ShowActivityLog()
        {
            List<Activity> activitylog = _dbContext.ActivityLog.ToList();
            return View(activitylog);            
        }
    }
}
