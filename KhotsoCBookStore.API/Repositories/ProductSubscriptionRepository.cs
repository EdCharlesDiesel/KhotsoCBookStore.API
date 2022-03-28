using KhotsoCBookStore.API.Contexts;
using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Repositories
{
    public class ProductSubscriptionRepository : IProductSubscriptionService
    {
        readonly KhotsoCBookStoreDbContext _dbContext;


        public ProductSubscriptionRepository(KhotsoCBookStoreDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        public Task<IEnumerable<Book>> GetAllBookSubscriptionsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetProductSubscriptionById(Guid customerId)
        {
            try
            {
                ProductSubscription productSubscription = new ProductSubscription
                {
                    ProductSubscriptionId = Guid.NewGuid(),
                    CustomerId = customerId,
                    DateOfSubscription = DateTime.Now,
                    CreatedOn = DateTime.Now.Date
                };

                 await _dbContext.ProductSubscriptions.AddAsync(productSubscription);
                 await _dbContext.SaveChangesAsync();

                return productSubscription.ProductSubscriptionId.ToString();
            }
            catch (System.Exception ex)
            {
                 throw new AggregateException(ex.Message);
            }
        }

        public async Task CreateProductSubscriptionItemAsync(Guid customerId,Guid bookId)
        {
            try
            {
                var book = await _dbContext.Books.FirstOrDefaultAsync(b=>b.BookId == bookId);
                var customer = await _dbContext.Customers.FindAsync(customerId);
                var productSubscriptionId = await GetProductSubscriptionById(customerId);
                var newProductSubscriptionId = new Guid(productSubscriptionId);

                var existingProductSubscriptionItem =
                 _dbContext.ProductSubscriptionItems.FirstOrDefault(x => x.ProductId == bookId
                  && x.ProductSubscriptionId.ToString() == productSubscriptionId);

                if (existingProductSubscriptionItem != null)
                {
                    _dbContext.ProductSubscriptionItems.Remove(existingProductSubscriptionItem);
                    await _dbContext.SaveChangesAsync();
                }

                ProductSubscriptionItem productSubscriptionItem = new ProductSubscriptionItem
                {
                    ProductSubscriptionId = newProductSubscriptionId,
                    ProductId = bookId,
                    NameOfSubscription = book.Title
                };
                await _dbContext.ProductSubscriptionItems.AddAsync(productSubscriptionItem);
                await _dbContext.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

         public async Task<int> ClearProductSubscriptionAsync(Guid customerId)
        {
            try
            {
                var productSubscriptionId = await GetProductSubscriptionById(customerId);
                List<ProductSubscriptionItem> productSubscriptionItem = _dbContext.ProductSubscriptionItems
                 .Where(x => x.ProductSubscriptionId.ToString() == productSubscriptionId).ToList();

                if (!string.IsNullOrEmpty(productSubscriptionId))
                {
                    foreach (ProductSubscriptionItem item in productSubscriptionItem)
                    {
                        _dbContext.ProductSubscriptionItems.Remove(item);
                        await _dbContext.SaveChangesAsync();
                    }
                }
                return 0;
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

        public Task CreateProductSubscriptionAsync(Guid customerId)
        {
            throw new NotImplementedException();
        }
    }
}
