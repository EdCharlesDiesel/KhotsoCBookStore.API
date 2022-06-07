using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StarPeaceAdminHubDB.Models
{
    public class Book : Entity<int>, IBook
    {
        public void FullUpdate(IBookFullEditDTO o)
        {
            if (IsTransient())
            {
                Id = o.BookId;
            }

            Title = o.Title;
            ISBN = o.ISBN;
            PublishingDate = o.PublishingDate;
            UnitCost = o.UnitCost;
            SupplierId = o.SupplierId;
            UnitPrice = o.UnitPrice;
            UnitsInStock = o.UnitsInStock;
            UnitsOnOrder = o.UnitsOnOrder;
            ReorderLevel = o.ReorderLevel;
            Discontinued = o.Discontinued;
        }

        [MaxLength(128), Required]
        public string Title { get; set; }

        public string ISBN { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime PublishingDate { get; set; }

        public string CoverFileName { get; set; }
        public decimal UnitCost { get; set; }
        public int? SupplierId { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        [ConcurrencyCheck]
        public long EntityVersion { get; set; }  
              
              
              public ICollection<Author> Authors { get; set; }
    }
}

       
