using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace StarPeaceAdminHubDB.Models
{
    public class Book: Entity<Guid>, IBook
    {
        
        [MaxLength(128), Required]
        public string Title { get; set; }


        [MaxLength(128), Required]
        public string ISBN { get; set; }        

        [Required]
        public DateTime PublishingDate { get; set; }
        
        //public Guid PublisherId { get; set; }
        
        public decimal Cost { get; set; }    

        public decimal RetailPrice { get; set; }     
        
        public string CoverFileName { get; set; }
        public ICollection<Category> Categorys { get; set; }

        public void FullUpdate(IBook o)
        {
            if (IsTransient())
            {
                Id = o.Id;
            }
            CategoryName = o.CategoryName;
        }
    }
}
