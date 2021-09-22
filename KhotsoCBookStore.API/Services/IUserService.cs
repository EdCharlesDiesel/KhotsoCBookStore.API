using KhotsoCBookStore.API.Authentication;
using System.Collections.Generic;

namespace KhotsoCBookStore.API.Services
{
    public interface IUserService
    {
        UserMaster Authenticate(string username, string password);
        UserMaster RegisterUser(UserMaster user, string password);
        bool CheckUserAvailabity(string userName);

        bool isUserExists(int userId);

        IEnumerable<UserMaster> GetAll();

        UserMaster GetById(int userId);

        void Update(UserMaster userParam, string password = null);
        void Delete(int userId);

    }
}
