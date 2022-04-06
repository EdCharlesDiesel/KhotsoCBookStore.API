using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Services
{
    public interface ICategoryService
    {
        Task CreateCategoryAsync(Category newcategory);

        Task<IEnumerable<Category>> GetAllCategoriesAync();
        
        Task<Category> GetCategoryByIdAsync(Guid categoryId);
        
        Task UpdateCategoryAsync(Category oldCategoryToUpdate);
        
        void DeleteCategory(Category categoryToDelete);

        Task<bool> SaveChangesAsync();

        Task<bool> CategoryIfExistsAsync(Guid categoryId);        
        
    }
}