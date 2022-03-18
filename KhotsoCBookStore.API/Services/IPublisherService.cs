using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Dtos;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Services
{
    public interface IPublisherService
    {
        Task<IEnumerable<Publisher>> GetAllPublishersAync();
        Task GetPublisherByIdAsync(Guid publisherId);
        Task CreatePublisherAsync(Publisher newPublisher);
        Task SaveChangesAsync();
        Task<bool> PublisherIfExistsAsync(Guid publisherId);
        void DeletePublisher(Publisher publisherEntity);
    }
}