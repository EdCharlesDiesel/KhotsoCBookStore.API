using System;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Dtos;

namespace KhotsoCBookStore.API.Services
{
    internal interface IPublisherService
    {
        Task GetAllPublishersAync();
        Task GetPublisherAsync(Guid publisherId);
        Task CreatePublisherAsync(PublisherForCreateDto newPublisher);
        Task SaveChangesAsync();
        Task<bool> PublisherIfExistsAsync(Guid publisherId);
        void DeletePublisher(object publisherEntity);
    }
}