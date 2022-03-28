using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Services
{
    public interface IPromotionService
    {
        Task<IEnumerable<Promotion>> GetAllPromotionsAync();
        
        Task<Promotion> GetPromotionByIdAsync(Guid PromotionId);

        Task CreatePromotionAsync(Promotion newPromotion);

        Task<Book> UpdatePromotionAsync(Book promotionToUpdate);

        void DeletePromotion(Guid PromotionId); 
        
        Task<bool> SaveChangesAsync();

        Task<bool> PromotionIfExistsAsync(Guid PromotionId);   
    }
}