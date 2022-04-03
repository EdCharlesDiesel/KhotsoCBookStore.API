using KhotsoCBookStore.API.Authentication;
using KhotsoCBookStore.API.Contexts;
using KhotsoCBookStore.API.Helpers;
using KhotsoCBookStore.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Repositories
{
    public class AccountRepository : IAccountService
    {
        readonly KhotsoCBookStoreDbContext _dbContext;
        public AccountRepository(KhotsoCBookStoreDbContext context)
        {
            _dbContext = context ?? throw new NotImplementedException();
        }

        public async Task<int> RegisterUser(UserMaster userData)
        {
           try
           {
               userData.UserTypeId = userData.UserId;
               await _dbContext.UserMasters.AddAsync(userData);
               _dbContext.SaveChanges();
               return 1;
           }
           catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }
        
        public async Task<UserMaster> GetUserById(Guid userId)
        {
           var userDetails = await _dbContext.UserMasters.FindAsync(userId);

           try
           {
                if (userDetails != null)
                {
                  var  user = new UserMaster
                   {
                       Username = userDetails.Username,
                       UserId = userDetails.UserId,
                       UserTypeId = userDetails.UserTypeId
                   };
                   return user;
                }
                else
                {
                   return userDetails;
                }
           }
          catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }     

        public List<UserMaster> GetAllUsers()
        {
            return  _dbContext.UserMasters.OrderBy(u=>u.LastName).ToList();
        }   

        public bool CheckIfUserExists(Guid userId)
        {
            try
            {
                var user = _dbContext.UserMasters.FirstOrDefault(u=>u.UserId == userId);
    
                if (user != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public bool CheckUserAvailabity(string userName)
        {
            
            try
            {
                var user =  _dbContext.UserMasters.FirstOrDefault(x => x.Username == userName)?.ToString();
                if (user != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public async Task<UserMaster> Authenticate(string username, string password)
        {
        //    try
        //    {
        //        _dbContext.UserMasters.FirstOrDefault.
        //    }
        //    catch (System.Exception ex)
        //     {
        //         throw new AggregateException(ex.Message);
        //     }

        throw new NotImplementedException();
        }

        public async Task<UserMaster> GetUserId(Guid userId)
        {
            return await _dbContext.UserMasters.FindAsync(userId);
        }

        public async Task<UserMaster> RegisterUser(UserMaster user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_dbContext.UserMasters.Any(x => x.Username == user.Username))
                throw new AppException("Username \"" + user.Username + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

           await _dbContext.UserMasters.AddAsync(user);
            _dbContext.SaveChanges();

            return user;
        }

        public void UpdateUser(UserMaster userParam, string password = null)
        {
            var user = _dbContext.UserMasters.Find(userParam.UserId);

            if (user == null)
                throw new AppException("UserMaster not found");

            // update username if it has changed
            if (!string.IsNullOrWhiteSpace(userParam.Username) && userParam.Username != user.Username)
            {
                // throw error if the new username is already taken
                if (_dbContext.UserMasters.Any(x => x.Username == userParam.Username))
                    throw new AppException("Username " + userParam.Username + " is already taken");

                user.Username = userParam.Username;
            }

            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(userParam.FirstName))
                user.FirstName = userParam.FirstName;

            if (!string.IsNullOrWhiteSpace(userParam.LastName))
                user.LastName = userParam.LastName;

            if (!string.IsNullOrWhiteSpace(userParam.EmailAddress))
                user.EmailAddress = userParam.EmailAddress;

            // update password if provided
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _dbContext.UserMasters.Update(user);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _dbContext.UserMasters.Find(id);
            if (user != null)
            {
                _dbContext.UserMasters.Remove(user);
                _dbContext.SaveChanges();
            }
        }

        // private helper methods
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        } 
        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return (await _dbContext.SaveChangesAsync() >= 0);
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }        

        public void Delete(UserMaster user)
        {
            throw new NotImplementedException();
        }

        bool IAccountService.CheckUserAvailabity(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
