using KhotsoCBookStore.API.Authentication;
using System;
using System.Collections.Generic;

namespace KhotsoCBookStore.API.Services
{
    public interface IUserService
    {
        UserMaster Authenticate(string username, string password);
        
        UserMaster RegisterUser(UserMaster user, string password);
        
        bool CheckUserAvailabity(string userName);

        bool isUserExists(Guid userId);

        IEnumerable<UserMaster> GetAll();

        UserMaster GetById(Guid userId);

        void Update(UserMaster userParam, string password = null);
        
        void Delete(Guid userId);

    }
}
