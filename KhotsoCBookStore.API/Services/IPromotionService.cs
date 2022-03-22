using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Services
{
    public interface IPromotionService
    {
        Task ClearPromotion(Guid userId);
        Task<string> GetPromotionId(Guid userId);
        Task TogglePromotionItem(Guid userId, Guid bookId);
        Task<IEnumerable<Promotion>> GetAllPromotionsAync();
    }
}