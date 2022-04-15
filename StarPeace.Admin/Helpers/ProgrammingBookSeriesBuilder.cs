using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarPeace.Admin.Services;
using StarPeace.Admin.Entities;

namespace StarPeace.Admin.Helpers
{
    public class ProgrammingBookSeriesBuilder:IBookSeriesBuilder
    {
        private BookSeries bookSeries;

        public ProgrammingBookSeriesBuilder()
        {
            bookSeries = new BookSeries();
            bookSeries.BookSeriesBooks = new List<BookSeriesBook>();
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
