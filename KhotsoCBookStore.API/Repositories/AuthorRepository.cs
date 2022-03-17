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
    public class AuthorRepository : IAuthorService
    {
        readonly KhotsoCBookStoreDbContext _dbContext;

        public AuthorRepository(KhotsoCBookStoreDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAync()
        {
            return await _dbContext.Authors.OrderBy(e=>e.LastName).ToListAsync();
        }

        public async Task<Author> GetAuthorByIdAsync(Guid authorId)
        {
            return await _dbContext.Authors.FirstOrDefaultAsync(c => c.AuthorId == authorId);
        }

        public async Task CreateAuthorAsync(Author newAuthor)
        {
            if (newAuthor != null)
            {
               await _dbContext.AddAsync(newAuthor);
            }
        }

        public Task<Author> UpdateAuthorAsync(Author author)
        {
            throw new NotImplementedException();
        }

        public void DeleteAuthor(Author authorToDelete)
        {
            _dbContext.Authors.Remove(authorToDelete);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _dbContext.SaveChangesAsync() >= 0);
        }

        public async Task<bool> AuthorIfExistsAsync(Guid authorId)
        {
            return await _dbContext.Authors.AnyAsync(c => c.AuthorId == authorId);
        }

        public Task<Author> UpdateAuthorAsync(AuthorForUpdateDto authorToUpdate)
        {
            throw new NotImplementedException();
        }

    }
}
