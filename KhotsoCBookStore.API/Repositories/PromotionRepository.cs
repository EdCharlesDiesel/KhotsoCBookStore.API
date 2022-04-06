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
    public class PromotionRepository : IPromotionService
    {
        readonly KhotsoCBookStoreDbContext _dbContext;

        public PromotionRepository(KhotsoCBookStoreDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        public async Task CreatePromotionAsync(Promotion newPromotion)
        {
            try
            {
                if (newPromotion != null)
                {
                   await _dbContext.AddAsync(newPromotion);
                }
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public async Task<IEnumerable<Promotion>> GetAllPromotionsAync()
        {
            try
            {
                return await _dbContext.Promotions.OrderBy(e=>e.MinimumRetail).ToListAsync();
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }      
        
        public async Task<Promotion> GetPromotionByIdAsync(Guid promotionId)
        {
            try
            {
                return await _dbContext.Promotions.FirstOrDefaultAsync(c => c.PromotionId == promotionId);
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public Task UpdatePromotionAsync(Book oldPromotionToUpdate)
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
        public void DeletePromotion(Promotion promotionToDelete)
        {
            try
            {
                _dbContext.Promotions.Remove(promotionToDelete);
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

        public async Task<bool> PromotionIfExistsAsync(Guid promotionId)
        {
            try
            {
                return await _dbContext.Promotions.AnyAsync(c => c.PromotionId == promotionId);
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }        
    }
}
