using StarPeace.Admin.Entities;
using StarPeace.Admin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Admin.Helpers
{
    public class ForumNotifier:IForumNotifier
    {
        private static List<IForumObserver> observers;

        static ForumNotifier()
        {
            observers = new List<IForumObserver>();
        }

        public void Subscribe(IForumObserver observer)
        {
            observers.Add(observer);
        }

        public void Unsubscribe(IForumObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify(ForumPost post)
        {
            foreach(IForumObserver observer in observers)
            {
                observer.Update(post);
            }
        }

    }
}
