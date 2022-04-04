using KhotsoCBookStore.API.Authentication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Services
{
    public interface IAccountService
    {
        Task<UserMaster> Authenticate(string username, string password);

        Task<UserMaster> RegisterUser(UserMaster user, string password);

        UserMaster GetUserBy(Guid userId);

        Task<IEnumerable<UserMaster>> GetAllUsersAsync();

        Task<bool> CheckUserAvailabityAsync(string userName);

        Task<bool> CheckIfUserExistsAsync(Guid userId);

        Task UpdateUserAsync(UserMaster userParam, string password = null);
        
        void DeleteUser(UserMaster userToDelete);

        Task<bool> SaveChangesAsync();
    }
}
