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

        Task<UserMaster> GetUserById(Guid userId);

        bool CheckUserAvailabity(string userName);

        bool CheckIfUserExists(Guid userId);

        List<UserMaster> GetAllUsers();        

        void UpdateUser(UserMaster userParam, string password = null);
        
        void Delete(UserMaster user);

        Task<bool> SaveChangesAsync();
    }
}
