using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarPeaceAdminHubDomain.Services;
using  StarPeaceAdminHubDomain.Products;

namespace StarPeaceAdminHubDomain.BuilderInterface
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
            builder.AddVideoSeries();
            builder.AddBookMarker();
            builder.AddHardCover();
            builder.AddFreeDelivery();
            builder.AddPoints();

            return builder.GetBookSeries();
        }

    }
}
