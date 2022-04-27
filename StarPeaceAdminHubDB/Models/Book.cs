using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.DTOs;
using StarPeaceAdminHubDomain.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB.Models
{
    public class Book: Entity<int>, IBook
    {        
        public string Title { get; set; }
       
        public string ISBN { get; set; }  
        
        public string Descripion { get; set; }     

        [Required]
        public DateTime PublishingDate { get; set; }
        
        public decimal Cost { get; set; }    

        public decimal RetailPrice { get; set; }     
        
        public string CoverFileName { get; set; }

        [ConcurrencyCheck]
        public long EntityVersion{ get; set; }
        
        public ICollection<Category> Categorys { get; set; }

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
