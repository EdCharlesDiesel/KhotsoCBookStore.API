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

        public async Task<Author> GetAuthorAsync(Guid authorId)
        {
            return await _dbContext.Authors.FirstOrDefaultAsync(c => c.AuthorId == authorId);
        }

        public async Task<Author> CreateAuthorAsync(AuthorForCreateDto newAuthor)
        {
            if (newAuthor != null)
            {
               await _dbContext.AddAsync(newAuthor);
            }

            return await _dbContext.Authors.LastOrDefaultAsync();
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

        // public Task<IEnumerable<AuthorDto>> GetAllAuthorsAync()
        // {
        //     throw new NotImplementedException();
        // }

        public Task<Author> UpdateAuthorAsync(AuthorForUpdateDto authorToUpdate)
        {
            throw new NotImplementedException();
        }

        // public async Task<IEnumerable<Author>> GetAllAuthorsAync()
        // {
        //     throw new NotImplementedException();
        // }

        Task IAuthorService.GetAuthorAsync(Guid authorId)
        {
            throw new NotImplementedException();
        }

        Task IAuthorService.CreateAuthorAsync(AuthorForCreateDto newAuthor)
        {
            throw new NotImplementedException();
        }

        Task IAuthorService.SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void DeleteAuthor(object authorEntity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<AuthorDto>> IAuthorService.GetAllAuthorsAync()
        {
            throw new NotImplementedException();
        }
    }
}
