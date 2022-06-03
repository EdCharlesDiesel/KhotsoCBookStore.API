using System;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.DTOs;

namespace KhotsoCBookStore.API.Models.Books
{
    public class BookFullEditViewModel: IBookFullEditDTO
    {
        public BookFullEditViewModel(IBook o)
        {
            Id = o.Id;
            Title = o.Title;
            ISBN = o.ISBN;
            Descripion = o.Description;
            Cost = o.Cost;
            PublishingDate= o.PublishingDate;
            RetailPrice = o.RetailPrice;
            CoverFileName= o.CoverFileName;
        }


        public int Id { get ;set; }

        public string Title { get; set ;}
        public string ISBN { get; set; }

        public string Descripion { get ; set; }

        public DateTime PublishingDate { get ;set; }

        public decimal Cost { get;set ; }

        public decimal RetailPrice { get ;set ; }

        public string CoverFileName { get ; set; }
    }
}
