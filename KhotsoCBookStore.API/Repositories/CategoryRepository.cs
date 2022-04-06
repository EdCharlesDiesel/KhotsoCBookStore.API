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
    public class CategoryRepository : ICategoryService
    {
        readonly KhotsoCBookStoreDbContext _dbContext;

        public CategoryRepository(KhotsoCBookStoreDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        public async Task CreateCategoryAsync(Category category)
        {
            try
            {
                if (category != null)
                {
                    await _dbContext.AddAsync(category);
                }    
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAync()
        {
            try
            {
                return await _dbContext.Categories.OrderBy(b => b.CategoryName).ToListAsync();
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public async Task<Category> GetCategoryByIdAsync(Guid categoryId)
        {
            try
            {
                return await _dbContext.Categories.FirstOrDefaultAsync(b=>b.CategoryId==categoryId);
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }       

        public  Task UpdateCategoryAsync(Category oldCategoryToUpdate)
        {
            try
            {                    
                // Category oldCategoryData = GetCategoryData(category.CategoryId);

                // if (oldCategoryData.CoverFileName != null)
                // {
                //     if (category.CoverFileName == null)
                //     {
                //         category.CoverFileName = oldCategoryData.CoverFileName;
                //     }
                // }

                // _dbContext.Entry(category).State = EntityState.Modified;
                // _dbContext.SaveChanges();  
                throw new NotImplementedException();              
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public void DeleteCategory(Category categoryToDelete)
        {
            try
            {
                _dbContext.Categories.Remove(categoryToDelete);
                
            }
             catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public async Task<bool> CategoryIfExistsAsync(Guid categoryId)
        {
            try
            {
                Category category = await _dbContext.Categories.FindAsync(categoryId);
                if (category!=null)
                {
                    return true;
                }
                return false;
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
    }
}
