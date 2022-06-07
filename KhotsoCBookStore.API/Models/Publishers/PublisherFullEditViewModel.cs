using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.DTOs;

namespace KhotsoCBookStore.API.Models.Books
{
    public class PublisherFullEditViewModel: IPublisherFullEditDTO
    {
        public PublisherFullEditViewModel() { }
        public PublisherFullEditViewModel(IPublisher o)
        {
            PublisherId = o.Id;
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
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string HomePage { get; set; }
    }
}
