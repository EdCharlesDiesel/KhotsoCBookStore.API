using DDD.DomainLayer;
using StarPeaceAdminHubDomain.DTOs;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public interface IPublisher : IEntity<int>
    {
        void FullUpdate(IPublisherFullEditDTO o); 

        int PublisherId { get; set; }

        public string CompanyName { get; set; }

        string ContactName { get; set; }

        string ContactTitle { get; set; }

        string Address { get; set; }

        string City { get; set; }

        string Region { get; set; }

        string PostalCode { get; set; }

        string Country { get; set; }

        string Phone { get; set; }

        string Fax { get; set; }

       string HomePage { get; set; }       
    }    
}
