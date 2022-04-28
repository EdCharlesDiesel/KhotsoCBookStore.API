using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.DTOs;
using StarPeaceAdminHubDomain.Events;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StarPeaceAdminHubDB.Models
{
    public class Book
    {
        [MaxLength(128), Required]
        public string Title { get; set; }
        [MaxLength(128)]
        public string Description { get; set; }
        
        public int DurationOnShelfInDays { get; set; }
        public DateTime? StartValidityDate { get; set; }
        public DateTime? EndValidityDate { get; set; }
        public Category Category { get; set; }

        public Guid CategoryId { get; set; }

        [Required]
        public DateTime PublishingDate { get; set; }
        
        public Guid PublisherId { get; set; }

        public Publisher Publisher { get; set; }

        public decimal Cost { get; set; }    

        public decimal RetailPrice { get; set; }     
        
        public string CoverFileName { get; set; }
    }
}
