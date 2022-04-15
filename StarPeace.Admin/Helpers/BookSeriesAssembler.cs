using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarPeace.Admin.Services;
using StarPeace.Admin.Entities;

namespace StarPeace.Admin.Helpers
{
    public class BookSeriesAssembler
    {
        private IBookSeriesBuilder builder;

        public BookSeriesAssembler(IBookSeriesBuilder builder)
        {
            this.builder = builder;
        }

        public BookSeries AssembleBookSeries()
        {
   
            builder.AddHardCover();            
            builder.AddBookMarker();            
            builder.AddNoteBook();
            builder.AddSourceCodeForBook();
            builder.AddBookVideos();

            return builder.GetBookSeries();
        }
    }
}
