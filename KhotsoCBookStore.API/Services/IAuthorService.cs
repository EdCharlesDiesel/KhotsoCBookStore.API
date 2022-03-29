using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Services
{
    public interface IAuthorService
    {
        Task CreateAuthorAsync(Author newAuthor);

        Task<IEnumerable<Author>> GetAllAuthorsAync();
        
        Task<Author> GetAuthorByIdAsync(Guid authorId);        

        Task UpdateAuthorAsync(Author oldAuthorToUpdate);

        void DeleteAuthor(Author authorToDelete); 
        
        Task<bool> SaveChangesAsync();

        Task<bool> AuthorIfExistsAsync(Guid authorId);     
        
    }
}