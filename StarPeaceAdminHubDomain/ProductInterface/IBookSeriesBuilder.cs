using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDomain.Services
{
    public interface IBookSeriesBuilder
    {
        void AddVideoSeries();
        void AddBookMarker();
        void AddHardCover();
        void AddPoints();
        void AddFreeDelivery();
        // GetBookSeries();
    }
}
