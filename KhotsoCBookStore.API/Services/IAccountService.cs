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

        Task<bool> CheckUserAvailabity(string userName);

        Task<bool> CheckIfUserExists(Guid userId);

        IEnumerable<UserMaster> GetAllUsers();

        UserMaster GetUserById(Guid userId);

        Task Update(UserMaster userParam, string password = null);
        
        void Delete(UserMaster user);

        Task<bool> SaveChangesAsync();
    }
}
