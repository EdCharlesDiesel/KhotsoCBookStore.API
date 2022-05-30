// using KhotsoCBookStore.API.Contexts;
// using KhotsoCBookStore.API.Entities;
// using KhotsoCBookStore.API.Dtos;
// using KhotsoCBookStore.API.Services;
// using Microsoft.EntityFrameworkCore;
// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace KhotsoCBookStore.API.Repositories
// {
//     public class ProductSubscriptionRepository : IProductSubscriptionService
//     {
//         readonly KhotsoCBookStoreDbContext _dbContext;

//         public ProductSubscriptionRepository(KhotsoCBookStoreDbContext dbContext)
//         {
//             _dbContext = dbContext;
//         }


//         public void ToggleProductSubscriptionItem(Guid customer, Guid productId)
//         {
//             // var productSubscriptionId = GetProductSubscriptionId(customer);
//             // ProductSubscriptionItem existingProductSubscriptionItem =
//             //  _dbContext.ProductSubscriptionItems.FirstOrDefault(x => x.ProductId == productId
//             //   && x.ProductSubscriptionId == productSubscriptionId);

//             // if (existingProductSubscriptionItem != null)
//             // {
//             //     _dbContext.ProductSubscriptionItems.Remove(existingProductSubscriptionItem);
//             //     _dbContext.SaveChanges();
//             // }
//             // else
//             // {
//             //     ProductSubscriptionItem productSubscriptionItem = new ProductSubscriptionItem
//             //     {
//             //         //ProductSubscriptionId = productSubscriptionId,
//             //         ProductId = productId,
//             //     };
//             //     _dbContext.ProductSubscriptionItems.Add(productSubscriptionItem);
//             //     _dbContext.SaveChanges();
//             // }
//         }

//         public int ClearProductSubscription(Guid customer)
//         {
//             try
//             {
//                 string productSubscriptionId = GetProductSubscriptionId(customer);
//                 // List<ProductSubscriptionItem> productSubscriptionItem = _dbContext.ProductSubscriptionItems
//                 // .Where(x => x.ProductSubscriptionId == productSubscriptionId).ToList();

//                 if (!string.IsNullOrEmpty(productSubscriptionId))
//                 {
//                     // foreach (ProductSubscriptionItem item in productSubscriptionItem)
//                     // {
//                     //     _dbContext.ProductSubscriptionItems.Remove(item);
//                     //     _dbContext.SaveChanges();
//                     // }
//                 }
//                 return 0;
//             }
//             catch
//             {
//                 throw;
//             }
//         }


//         public string GetProductSubscriptionId(Guid customer)
//         {
//             try
//             {
//                 ProductSubscription productSubscription = _dbContext.ProductSubscriptions.FirstOrDefault(x => x.CustomerId == customer);

//                 if (productSubscription != null)
//                 {
//                     return productSubscription.ProductSubscriptionId.ToString();
//                 }
//                 else
//                 {
//                     return CreateProductSubscription(customer);
//                 }

//             }
//             catch
//             {
//                 throw;
//             }
//         }

//         string CreateProductSubscription(Guid customer)
//         {
//             try
//             {
//                 ProductSubscription productSubscription = new ProductSubscription
//                 {
//                     ProductSubscriptionId = Guid.NewGuid(),
//                     CustomerId = customer,
//                     CreatedOn = DateTime.Now.Date
//                 };

//                 _dbContext.ProductSubscriptions.Add(productSubscription);
//                 _dbContext.SaveChanges();

//                 return productSubscription.ProductSubscriptionId.ToString();
//             }
//             catch
//             {
//                 throw;
//             }
//         }
//     }
// }
