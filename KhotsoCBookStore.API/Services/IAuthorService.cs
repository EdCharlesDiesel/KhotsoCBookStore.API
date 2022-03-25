using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAuthorsAync();
        
        Task<Author> GetAuthorByIdAsync(Guid authorId);

        Task CreateAuthorAsync(Author newAuthor);
        
        Task<bool> AuthorIfExistsAsync(Guid authorId);

        Task<bool> SaveChangesAsync();
        
        //void DeleteAuthor(Author authorEntity);
        void DeleteAuthor(Guid authorId);
    }
}