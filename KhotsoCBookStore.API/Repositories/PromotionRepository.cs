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
    public class PromotionRepository : IPromotionService
    {
        readonly KhotsoCBookStoreDbContext _dbContext;

        public PromotionRepository(KhotsoCBookStoreDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        public async Task<IEnumerable<Promotion>> GetAllPromotionsAync()
        {
            return await _dbContext.Promotions.OrderBy(e=>e.ManimumRetail).ToListAsync();
        }

        public async Task<Promotion> GetPromotionAsync(Guid promotionId)
        {
            return await _dbContext.Promotions.FirstOrDefaultAsync(c => c.PromoId == promotionId);
        }

        public async Task<Dtos.PromotionForCreateDto> CreatePromotionAsync(Dtos.PromotionForCreateDto newPromotion)
        {
            if (newPromotion != null)
            {
               await _dbContext.AddAsync(newPromotion);
            }

            return  null;
        }

        public Task<Promotion> UpdatePromotionAsync(Promotion promotion)
        {
            throw new NotImplementedException();
        }

        public void DeletePromotion(Promotion promotionToDelete)
        {
            _dbContext.Promotions.Remove(promotionToDelete);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _dbContext.SaveChangesAsync() >= 0);
        }

        public async Task<bool> PromotionIfExistsAsync(Guid promotionId)
        {
            return await _dbContext.Promotions.AnyAsync(c => c.PromoId == promotionId);
        }

       

        public Task<Promotion> UpdatePromotionAsync(Dtos.PromotionForUpdateDto promotionToUpdate)
        {
            throw new NotImplementedException();
        }

        public int ClearPromotion(Guid userId)
        {
            throw new NotImplementedException();
        }

        public string GetPromotionId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void TogglePromotionItem(Guid userId, Guid bookId)
        {
            throw new NotImplementedException();
        }

        Task IPromotionService.ClearPromotion(Guid userId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Entities.PromotionDto>> IPromotionService.GetAllPromotionsAync()
        {
            throw new NotImplementedException();
        }
    }
}
