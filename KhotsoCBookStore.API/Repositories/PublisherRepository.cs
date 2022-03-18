using KhotsoCBookStore.API.Contexts;
using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Dtos;
using KhotsoCBookStore.API.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Repositories
{
    public class PublisherRepository : IPublisherService
    {
        readonly KhotsoCBookStoreDbContext _dbContext;

        public PublisherRepository(KhotsoCBookStoreDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        public async Task<IEnumerable<Publisher>> GetAllPublishersAync()
        {
            return await _dbContext.Publishers.OrderBy(e=>e.Name).ToListAsync();
        }

        public async Task<Publisher> GetPublisherAsync(Guid publisherId)
        {
            return await _dbContext.Publishers.FirstOrDefaultAsync(c => c.PublisherId == publisherId);
        }

        public async Task<Publisher> CreatePublisherAsync(PublisherForCreateDto newPublisher)
        {
            if (newPublisher != null)
            {
               await _dbContext.AddAsync(newPublisher);
            }

            return await _dbContext.Publishers.LastOrDefaultAsync();
        }

        public Task<Publisher> UpdatePublisherAsync(Publisher publisher)
        {
            throw new NotImplementedException();
        }

        public void DeletePublisher(Publisher publisherToDelete)
        {
            _dbContext.Publishers.Remove(publisherToDelete);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _dbContext.SaveChangesAsync() >= 0);
        }

        public async Task<bool> PublisherIfExistsAsync(Guid publisherId)
        {
            return await _dbContext.Publishers.AnyAsync(c => c.PublisherId == publisherId);
        }

        // Task<IEnumerable<PublisherDto>> GetAllPublishersAync()
        // {
        //     throw new NotImplementedException();
        // }

        public Task<Publisher> UpdatePublisherAsync(PublisherForUpdateDto publisherToUpdate)
        {
            throw new NotImplementedException();
        }

       

       

        

        Task IPublisherService.SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void DeletePublisher(object publisherEntity)
        {
            throw new NotImplementedException();
        }

        public Task CreatePublisherAsync(Publisher newPublisher)
        {
            throw new NotImplementedException();
        }

        public Task GetPublisherByIdAsync(Guid publisherId)
        {
            throw new NotImplementedException();
        }
    }
}
