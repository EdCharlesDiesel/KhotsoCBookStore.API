using System.ComponentModel.DataAnnotations;
using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.DTOs;

namespace StarPeaceAdminHubDB
{
    public class Publisher : Entity<int>, IPublisher
    {
        public void FullUpdate(IPublisherFullEditDTO o)
        {
            if (IsTransient())
            {
                PublisherId = o.PublisherId;                
            }
            
            CompanyName = o.CompanyName;
            ContactName = o.ContactName;
            ContactTitle = o.ContactTitle;
            Address = o.Address;
            Address = o.Address;
            City = o.City;
            Region = o.Region;
            PostalCode = o.PostalCode;
            Country = o.Country;
            Phone = o.Phone;
            Fax = o.Fax;
            HomePage = o.HomePage;
        }    

        public int PublisherId { get; set; }

        [MaxLength(40)]
        public string CompanyName { get; set; }

        [MaxLength(30)]
        public string ContactName { get; set; }

        [MaxLength(30)]
        public string ContactTitle { get; set; }

        [MaxLength(60)]
        public string Address { get; set; }

        [MaxLength(15)]
        public string City { get; set; }

        [MaxLength(100)]
        public string Region { get; set; }

        [MaxLength(10)]
        public string PostalCode { get; set; }

        [MaxLength(15)]
        public string Country { get; set; }

        [MaxLength(24)]
        public string Phone { get; set; }

        [MaxLength(24)]
        public string Fax { get; set; }

        public string HomePage { get; set; }

        [ConcurrencyCheck]
        public long EntityVersion { get; set; }

      //  public IEnumerable<Products> Products { get; set; }
    }
}
