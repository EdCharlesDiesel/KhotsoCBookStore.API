using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StarPeaceAdminHubDB.Models
{
    public class Book: Entity<int>, IBook
    {      
        [MaxLength(128), Required]  
        public string Title { get; set; }

        [MaxLength(128), Required]       
        public string ISBN { get; set; }  
        
        [MaxLength(400)]
        public string Description { get; set; }     

        [Required]
        public DateTime PublishingDate { get; set; }
        
        public decimal Cost { get; set; }    

        public decimal RetailPrice { get; set; }     
        
        public string CoverFileName { get; set; }

        [ConcurrencyCheck]
        public long EntityVersion{ get; set; }
        
        public ICollection<Author> Authors { get; set; }

        public void FullUpdate(IBookFullEditDTO o)
        {
            if (IsTransient())
            {
                Id = o.Id;
            }

            Title = o.Title;
            ISBN = o.ISBN;
            PublishingDate = o.PublishingDate;        
            Cost = o.Cost; 
            RetailPrice = o.RetailPrice;            
            CoverFileName = o.CoverFileName;    
        }
    }
}
