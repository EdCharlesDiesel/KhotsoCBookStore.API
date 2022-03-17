using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Services
{
    internal interface IPromotionService
    {
        int ClearPromotion(Guid userId);
        string GetPromotionId(Guid userId);
        void TogglePromotionItem(Guid userId, Guid bookId);
        Task<IEnumerable<PromotionDto>> GetAllPromotionsAync();
    }
}