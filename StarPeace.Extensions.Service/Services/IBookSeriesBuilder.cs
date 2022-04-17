using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Extensions.Service.Services
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
