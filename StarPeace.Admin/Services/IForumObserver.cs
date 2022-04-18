using StarPeace.Admin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Admin.Services
{
    public interface IForumObserver
    {
        void Update(ForumPost post);
    }
}
