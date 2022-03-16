using KhotsoCBookStore.API.Contexts;
using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Dtos;
using KhotsoCBookStore.API.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KhotsoCBookStore.API.Repositories
{
    public class ProductSubscriptionRepository : IProductSubscriptionService
    {
        readonly KhotsoCBookStoreDbContext _dbContext;

        public ProductSubscriptionRepository(KhotsoCBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void ToggleProductSubscriptionItem(int userId, int productId)
        {
            string productSubscriptionId = GetProductSubscriptionId(userId);
            ProductSubscriptionItem existingProductSubscriptionItem = _dbContext.ProductSubscriptionItems.FirstOrDefault(x => x.ProductId == productId && x.ProductSubscriptionId == productSubscriptionId);

            if (existingProductSubscriptionItem != null)
            {
                _dbContext.ProductSubscriptionItems.Remove(existingProductSubscriptionItem);
                _dbContext.SaveChanges();
            }
            else
            {
                ProductSubscriptionItem productSubscriptionItem = new ProductSubscriptionItem
                {
                    ProductSubscriptionId = productSubscriptionId,
                    ProductId = productId,
                };
                _dbContext.ProductSubscriptionItems.Add(productSubscriptionItem);
                _dbContext.SaveChanges();
            }
        }

        public int ClearProductSubscription(int userId)
        {
            try
            {
                string productSubscriptionId = GetProductSubscriptionId(userId);
                List<ProductSubscriptionItem> productSubscriptionItem = _dbContext.ProductSubscriptionItems.Where(x => x.ProductSubscriptionId == productSubscriptionId).ToList();

                if (!string.IsNullOrEmpty(productSubscriptionId))
                {
                    foreach (ProductSubscriptionItem item in productSubscriptionItem)
                    {
                        _dbContext.ProductSubscriptionItems.Remove(item);
                        _dbContext.SaveChanges();
                    }
                }
                return 0;
            }
            catch
            {
                throw;
            }
        }


        public string GetProductSubscriptionId(int userId)
        {
            try
            {
                ProductSubscription productSubscription = _dbContext.ProductSubscription.FirstOrDefault(x => x.UserId == userId);

                if (productSubscription != null)
                {
                    return productSubscription.ProductSubscriptionId;
                }
                else
                {
                    return CreateProductSubscription(userId);
                }

            }
            catch
            {
                throw;
            }
        }

        string CreateProductSubscription(int userId)
        {
            try
            {
                ProductSubscription productSubscription = new ProductSubscription
                {
                    ProductSubscriptionId = Guid.NewGuid().ToString(),
                    UserId = userId,
                    DateCreated = DateTime.Now.Date
                };

                _dbContext.ProductSubscription.Add(productSubscription);
                _dbContext.SaveChanges();

                return productSubscription.ProductSubscriptionId;
            }
            catch
            {
                throw;
            }
        }
    }
}
