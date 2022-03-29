using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Services
{
    public interface IPublisherService
    {
        Task CreatePublisherAsync(Publisher newPublisher);

        Task<IEnumerable<Publisher>> GetAllPublishersAync();
        
        Task<Publisher> GetPublisherByIdAsync(Guid PublisherId);        

        Task UpdatePublisherAsync(Book oldPublisherToUpdate);

        void DeletePublisher(Publisher publisherToDelete); 
        
        Task<bool> SaveChangesAsync();

        Task<bool> PublisherIfExistsAsync(Guid PublisherId);   
    }
}