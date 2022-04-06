using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Services
{
    public interface IPromotionService
    {
        Task CreatePromotionAsync(Promotion newPromotion);

        Task<IEnumerable<Promotion>> GetAllPromotionsAync();
        
        Task<Promotion> GetPromotionByIdAsync(Guid PromotionId);        

        Task UpdatePromotionAsync(Book oldPromotionToUpdate);

        void DeletePromotion(Promotion promotionToDelete); 
        
        Task<bool> SaveChangesAsync();

        Task<bool> PromotionIfExistsAsync(Guid PromotionId);   
    }
}