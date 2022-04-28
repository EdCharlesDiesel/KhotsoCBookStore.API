using System;
using System.ComponentModel.DataAnnotations;
using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.DTOs;

namespace StarPeaceAdminHubDB
{
    public class BookTitle :  Entity<int>, IBookTitle
    {

        [MaxLength(50),Required(ErrorMessage = "ISBN is required")]
        public string ISBN { get; set; } 

        [Required(ErrorMessage = "Published Date is required")]
        public DateTime PublishedDate { get; set; } 

        [ConcurrencyCheck]
        public int EntityVersion { get; set; } 

        public int TitleId { get; set; }

        public void FullUpdate(IBookTitleFullEditDTO o)
        {
            Id = o.Id;
            ISBN = o.ISBN;
            PublishedDate = o.PublishingDate;
            TitleId = o.TitleId;
        }
    }
}
