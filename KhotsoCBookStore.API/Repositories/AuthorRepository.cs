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
    public class AuthorRepository : IAuthorService
    {
        readonly KhotsoCBookStoreDbContext _dbContext;

        public AuthorRepository(KhotsoCBookStoreDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        public async Task CreateAuthorAsync(Author newAuthor)
        {
            try
            {
                if (newAuthor != null)
                {
                    await _dbContext.AddAsync(newAuthor);
                }
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAync()
        {
            try
            {
                return await _dbContext.Authors.OrderBy(e => e.LastName).ToListAsync();
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public async Task<Author> GetAuthorByIdAsync(Guid authorId)
        {
            try
            {
                return await _dbContext.Authors.FirstOrDefaultAsync(c => c.AuthorId == authorId);
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }        

        public Task UpdateAuthorAsync(Author oldAuthorToUpdate)
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
        public void DeleteAuthor(Author authorToDelete)
        {
            try
            {                
                _dbContext.Authors.Remove(authorToDelete);
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

        public async Task<bool> AuthorIfExistsAsync(Guid authorId)
        {
            try
            {
                return await _dbContext.Authors.AnyAsync(c => c.AuthorId == authorId);
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }
    }
}
