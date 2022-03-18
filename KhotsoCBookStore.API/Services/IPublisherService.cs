using System;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Dtos;

namespace KhotsoCBookStore.API.Services
{
    public interface IPublisherService
    {
        Task GetAllPublishersAync();
        Task GetPublisherAsync(Guid publisherId);
        Task CreatePublisherAsync(PublisherForCreateDto newPublisher);
        Task SaveChangesAsync();
        Task<bool> PublisherIfExistsAsync(Guid publisherId);
        void DeletePublisher(object publisherEntity);
    }
}