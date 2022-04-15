using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarPeace.Admin.Entities;

namespace StarPeace.Admin.Services
{
    public interface IBookSeriesBuilder
    {
        void AddHardCover();
        
        void AddBookMarker();
        
        void AddNoteBook();

        void AddSourceCodeForBook();

        void AddBookVideos();
        
        BookSeries GetBookSeries();
    }
}
