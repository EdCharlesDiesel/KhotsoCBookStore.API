using KhotsoCBookStore.API.Authentication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Services
{
    public interface IUserService
    {
        Task<UserMaster> Authenticate(string username, string password);
        
        Task<UserMaster> RegisterUser(UserMaster user, string password);
        
        Task<bool> CheckUserAvailabity(string userName);

        Task<bool> CheckIfUserExists(Guid userId);

        Task<IEnumerable<UserMaster>> GetAllUsers();

        Task<UserMaster> GetUserById(Guid userId);

        Task UpdateUser(UserMaster userParam, string password = null);
        
        Task DeleteUser(Guid userId);
    }
}
