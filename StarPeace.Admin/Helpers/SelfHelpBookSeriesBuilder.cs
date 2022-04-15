using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarPeace.Admin.Services;
using StarPeace.Admin.Entities;


namespace StarPeace.Admin.Helpers
{
    public class SelfHelpBookSeriesBuilder:IBookSeriesBuilder
    {
       private BookSeries bookSeries;

        public SelfHelpBookSeriesBuilder()
        {
            bookSeries = new BookSeries();
            bookSeries.Parts = new List<BookSeriesPart>();
        }

        public void AddHardCover()
        {
           throw new NotImplementedException();
        }

        public void AddBookMarker()
        {
            throw new NotImplementedException();
        }

        public void AddNoteBook()
        {
            throw new NotImplementedException();
        }

        public void AddSourceCodeForBook()
        {
            throw new NotImplementedException();
        }

        public void AddBookVideos()
        {
           throw new NotImplementedException();
        }

        public BookSeries GetBookSeries()
        {
            return bookSeries;
        }
    }
}
