using KhotsoCBookStore.API.Contexts;
using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Models;
using KhotsoCBookStore.API.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KhotsoCBookStore.API.Repositories
{
    public class BookSubscriptionRepository : IBookSubscriptionService
    {
        readonly KhotsoCBookStoreDbContext _dbContext;

        public BookSubscriptionRepository(KhotsoCBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void ToggleBookSubscriptionItem(int userId, int bookId)
        {
            string bookSubscriptionId = GetBookSubscriptionId(userId);
            BookSubscriptionItems existingBookSubscriptionItem = _dbContext.BookSubscriptionItems.FirstOrDefault(x => x.ProductId == bookId && x.BookSubscriptionId == bookSubscriptionId);

            if (existingBookSubscriptionItem != null)
            {
                _dbContext.BookSubscriptionItems.Remove(existingBookSubscriptionItem);
                _dbContext.SaveChanges();
            }
            else
            {
                BookSubscriptionItems bookSubscriptionItem = new BookSubscriptionItems
                {
                    BookSubscriptionId = bookSubscriptionId,
                    ProductId = bookId,
                };
                _dbContext.BookSubscriptionItems.Add(bookSubscriptionItem);
                _dbContext.SaveChanges();
            }
        }

        public int ClearBookSubscription(int userId)
        {
            try
            {
                string bookSubscriptionId = GetBookSubscriptionId(userId);
                List<BookSubscriptionItems> bookSubscriptionItem = _dbContext.BookSubscriptionItems.Where(x => x.BookSubscriptionId == bookSubscriptionId).ToList();

                if (!string.IsNullOrEmpty(bookSubscriptionId))
                {
                    foreach (BookSubscriptionItems item in bookSubscriptionItem)
                    {
                        _dbContext.BookSubscriptionItems.Remove(item);
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


        public string GetBookSubscriptionId(int userId)
        {
            try
            {
                BookSubscription bookSubscription = _dbContext.BookSubscription.FirstOrDefault(x => x.UserId == userId);

                if (bookSubscription != null)
                {
                    return bookSubscription.BookSubscriptionId;
                }
                else
                {
                    return CreateBookSubscription(userId);
                }

            }
            catch
            {
                throw;
            }
        }

        string CreateBookSubscription(int userId)
        {
            try
            {
                BookSubscription bookSubscription = new BookSubscription
                {
                    BookSubscriptionId = Guid.NewGuid().ToString(),
                    UserId = userId,
                    DateCreated = DateTime.Now.Date
                };

                _dbContext.BookSubscription.Add(bookSubscription);
                _dbContext.SaveChanges();

                return bookSubscription.BookSubscriptionId;
            }
            catch
            {
                throw;
            }
        }


    }
}
