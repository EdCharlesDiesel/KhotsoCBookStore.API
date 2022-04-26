using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarPeaceAdminHubDomain.Products;
using StarPeaceAdminHubDomain.Services;

namespace StarPeaceAdminHubDomain.ConcreteBuilder
{
    public class SelfHelpBookSeriesBuilder: IBookSeriesBuilder
    {
        private BookSeries BookSeries;

        public SelfHelpBookSeriesBuilder()
        {
            BookSeries = new BookSeries();
            BookSeries.BookSeriesExtras = new List<BookSeriesExtras>();
        }

        public void AddVideoSeries()
        {
            // using (AppDbContext db = new AppDbContext())
            // {
            //     var query = from p in db.BookSeriesParts
            //                 where p.UseType == "Programming" && p.Part == "CPU"
            //                 select p;
            //     BookSeries.Parts.Add(query.SingleOrDefault());
            // }
            throw NotImplementedException();
        }

        public void AddBookMarker()
        {
            // using (AppDbContext db = new AppDbContext())
            // {
            //     var query = from p in db.BookSeriesParts
            //                 where p.UseType == "Programming" && p.Part == "CABINET"
            //                 select p;
            //     BookSeries.Parts.Add(query.SingleOrDefault());
            // }

            throw NotImplementedException();
        }

        public void AddHardCover()
        {
            // using (AppDbContext db = new AppDbContext())
            // {
            //     var query = from p in db.BookSeriesParts
            //                 where p.UseType == "Programming" && p.Part == "MOUSE"
            //                 select p;
            //     BookSeries.Parts.Add(query.SingleOrDefault());
            // }
            throw NotImplementedException();
        }

        public void AddFreeDelivery()
        {
            // using (AppDbContext db = new AppDbContext())
            // {
            //     var query = from p in db.BookSeriesParts
            //                 where p.UseType == "Programming" && p.Part == "KEYBOARD"
            //                 select p;
            //     BookSeries.Parts.Add(query.SingleOrDefault());
            // }
            throw NotImplementedException();
        }

        public void AddPoints()
        {
            // using (AppDbContext db = new AppDbContext())
            // {
            //     var query = from p in db.BookSeriesParts
            //                 where p.UseType == "Programming" && p.Part == "MONITOR"
            //                 select p;
            //     BookSeries.Parts.Add(query.SingleOrDefault());
            // }
            throw NotImplementedException();
        }

        public BookSeries GetBookSeries()
        {
            return BookSeries;
        }
    }
}
