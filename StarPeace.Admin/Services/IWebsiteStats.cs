using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeace.Admin.Services
{
    public interface IWebsiteStats
    {
        int Id { get; set; }
        string Host { get; set; }
        int PageViews { get; set; }
        int SiteVisits { get; set; }
        string TopKeywords { get; set; }
        int Bandwidth { get; set; }
        int GetActiveUsers();
    }
}
