using KhotsoCBookStore.API.Contexts;
using KhotsoCBookStore.API.Entities;
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

        public async Task CreatePublisherAsync(Publisher newPublisher)
        {
          try
          {
                if (newPublisher != null)
                {
                   await _dbContext.AddAsync(newPublisher);
                }
          }
          catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public async Task<IEnumerable<Publisher>> GetAllPublishersAync()
        {
            try
            {
                return await _dbContext.Publishers.OrderBy(e=>e.NameAndSurname).ToListAsync();
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public async Task<Publisher> GetPublisherByIdAsync(Guid publisherId)
        {
            try
            {
                return await _dbContext.Publishers.FirstOrDefaultAsync(c => c.PublisherId == publisherId);
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }       


        public Task UpdatePublisherAsync(Book oldPublisherToUpdate)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public void DeletePublisher(Publisher publisherToDelete)
        {
           try
            {
                var book = _dbContext.Books.Find(publisherToDelete.PublisherId);
                _dbContext.Books.Remove(book);
            }
             catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return (await _dbContext.SaveChangesAsync() >= 0);
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }        

        public async Task<bool> PublisherIfExistsAsync(Guid publisherId)
        {
            try
            {
                return await _dbContext.Publishers.AnyAsync(c => c.PublisherId == publisherId);
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }        
    }
}
