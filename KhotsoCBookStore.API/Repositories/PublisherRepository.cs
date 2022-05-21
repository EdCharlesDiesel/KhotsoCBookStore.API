// using KhotsoCBookStore.API.Contexts;
// using KhotsoCBookStore.API.Entities;
// using KhotsoCBookStore.API.DTOs;
// using KhotsoCBookStore.API.Services;
// using Microsoft.EntityFrameworkCore;
// using System.Collections.Generic;
// using System.Linq;
// using System;
// using System.Threading.Tasks;

// namespace KhotsoCBookStore.API.Repositories
// {
//     public class PublisherRepository : IPublisherService
//     {
//         readonly KhotsoCBookStoreDbContext _dbContext;

//         public PublisherRepository(KhotsoCBookStoreDbContext dbContext)
//         {
//             _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
//         }

//         public async Task<IEnumerable<Publisher>> GetAllPublishersAync()
//         {
//             return await _dbContext.Publishers.OrderBy(e=>e.Name).ToListAsync();
//         }

//         public async Task<Publisher> GetPublisherByIdAsync(Guid publisherId)
//         {
//             return await _dbContext.Publishers.FirstOrDefaultAsync(c => c.PublisherId == publisherId);
//         }

//         public async Task CreatePublisherAsync(Publisher newPublisher)
//         {
//             if (newPublisher != null)
//             {
//                await _dbContext.AddAsync(newPublisher);
//             }
//         }

//         public Task<Publisher> UpdatePublisherAsync(Publisher publisher)
//         {
//             throw new NotImplementedException();
//         }

//         public void DeletePublisher(Publisher publisherToDelete)
//         {
//            try
//             {
//                 var book = _dbContext.Books.Find(publisherToDelete.PublisherId);
//                 _dbContext.Books.Remove(book);
//             }
//              catch (System.Exception ex)
//             {
//                 throw new AggregateException(ex.Message);
//             }
//         }
        
//         public async Task<bool> SaveChangesAsync()
//         {
//             return (await _dbContext.SaveChangesAsync() >= 0);
//         }        

//         public async Task<bool> PublisherIfExistsAsync(Guid publisherId)
//         {
//             return await _dbContext.Publishers.AnyAsync(c => c.PublisherId == publisherId);
//         }   

//         public Task<Publisher> UpdatePublisherAsync(PublisherForUpdateDto publisherToUpdate)
//         {
//             throw new NotImplementedException();
//         }

//         public void DeletePublisher(object publisherEntity)
//         {
//             throw new NotImplementedException();
//         }  

      
//     }
// }
