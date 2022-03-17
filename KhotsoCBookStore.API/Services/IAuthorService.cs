using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Dtos;

namespace KhotsoCBookStore.API.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAllAuthorsAync();
        Task GetAuthorAsync(Guid authorId);
        Task CreateAuthorAsync(AuthorForCreateDto newAuthor);
        Task SaveChangesAsync();
        Task<bool> AuthorIfExistsAsync(Guid authorId);
        void DeleteAuthor(object authorEntity);
    }
}