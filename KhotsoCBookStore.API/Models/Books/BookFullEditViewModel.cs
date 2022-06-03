using System;
using System.ComponentModel.DataAnnotations;
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


        int Id { get; set; }

        string Title { get; set; }        

        string ISBN { get; set; }

        string Descripion { get; set; }
        
        DateTime PublishingDate { get; set; }
        
        decimal Cost { get; set; }    

        decimal RetailPrice { get; set; }     
        
        string CoverFileName { get; set; }
        
    }
}
