using KhotsoCBookStore.API.Contexts;
using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Dtos;
using KhotsoCBookStore.API.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KhotsoCBookStore.API.Repositories
{
    public class ProductSubscriptionRepository : IProductSubscriptionService
    {
        readonly KhotsoCBookStoreDbContext _dbContext;


        public ProductSubscriptionRepository(KhotsoCBookStoreDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        public async Task ToggleProductSubscriptionItem(Guid customerId, Guid productId)
        {
            // var customer = await _dbContext.Customers.FindAsync(customerId);
            // var productSubscriptionId = GetProductSubscriptionId(customerId);

            // ProductSubscriptionItem existingProductSubscriptionItem =
            //  _dbContext.ProductSubscriptionItems.FirstOrDefault(x => x.ProductId == productId
            //   && x.ProductSubscriptionId.ToString() == productSubscriptionId);

            // if (existingProductSubscriptionItem != null)
            // {
            //     _dbContext.ProductSubscriptionItems.Remove(existingProductSubscriptionItem);
            //     await _dbContext.SaveChangesAsync();
            // }

            ProductSubscriptionItem productSubscriptionItem = new ProductSubscriptionItem
            {
                //ProductSubscriptionId = productSubscriptionId,
                ProductId = productId,
            };
            await _dbContext.ProductSubscriptionItems.AddAsync(productSubscriptionItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> ClearProductSubscription(Guid customer)
        {
            try
            {
                // string productSubscriptionId = GetProductSubscriptionId(customer);
                // List<ProductSubscriptionItem> productSubscriptionItem = _dbContext.ProductSubscriptionItems
                //  .Where(x => x.ProductSubscriptionId.ToString() == productSubscriptionId).ToList();

                // if (!string.IsNullOrEmpty(productSubscriptionId))
                // {
                //     foreach (ProductSubscriptionItem item in productSubscriptionItem)
                //     {
                //         _dbContext.ProductSubscriptionItems.Remove(item);
                //         await _dbContext.SaveChangesAsync();
                //     }
                // }
                return 0;
            }
            catch
            {
                throw;
            }
        }

        public async Task<String> CreateProductSubscription(Guid customer)
        {
            try
            {
                ProductSubscription productSubscription = new ProductSubscription
                {
                    ProductSubscriptionId = Guid.NewGuid(),
                    CustomerId = customer,
                    DateOfSubscription = DateTime.Now,
                    CreatedOn = DateTime.Now.Date
                };

                await _dbContext.ProductSubscriptions.AddAsync(productSubscription);
                await _dbContext.SaveChangesAsync();

                return productSubscription.ProductSubscriptionId.ToString();
            }
            catch
            {
                throw;
            }
        }

        Task<string> IProductSubscriptionService.GetProductSubscriptionId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task ClearProductSubscriptionAsync(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetProductSubscriptionId()
        {
            throw new NotImplementedException();
        }

        public Task CreateProductSubscriptionAsync(ProductSubscription productSubscriptionToCreate)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetProductSubscription()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Book>> GetProductSubscriptionById(Guid customerId)
        {
            throw new NotImplementedException();
        }

        Task<int> IProductSubscriptionService.ClearProductSubscriptionAsync(Guid customerId)
        {
            throw new NotImplementedException();
        }
    }
}
