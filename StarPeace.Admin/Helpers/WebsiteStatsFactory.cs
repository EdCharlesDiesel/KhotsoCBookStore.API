using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StarPeace.Admin.Models;
using StarPeace.Admin.Helpers;
using StarPeace.Admin.Services;
using StarPeace.Admin.Entities;

namespace StarPeace.Admin.Helpers
{
    public class WebsiteStatsFactory
    {
        private static Dictionary<string, WebsiteStats> dictionary = new Dictionary<string, WebsiteStats>();

        public IWebsiteStats this[string host]
        {
            get
            {
                if(!dictionary.ContainsKey(host))
                {
                    using (AppDbContext db = new AppDbContext())
                    {
                        var query = from stats in db.WebsiteStats
                                    where stats.Host == host
                                    select stats;
                        dictionary[host] = query.SingleOrDefault();
                    }
                }
                return dictionary[host];
            }
        }
    }
}
