using KhotsoCBookStore.API.Authentication;
using KhotsoCBookStore.API.Contexts;
using KhotsoCBookStore.API.Helpers;
using KhotsoCBookStore.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KhotsoCBookStore.API.Repositories
{
    public class UserRepository : IUserService
    {
        readonly KhotsoCBookStoreDbContext _context;

        public UserRepository(KhotsoCBookStoreDbContext context)
        {
            _context = context;
        }

   
           // UserMaster user = new UserMaster();

            //var userDetails = _context.UserMaster.SingleOrDefault(
            //    u => u.Username == loginCredentials.Username && u.Password == loginCredentials.Password
            //    );

            //if (userDetails != null)
            //{

            //    user = new UserMaster
            //    {
            //        Username = userDetails.Username,
            //        UserId = userDetails.UserId,
            //        UserTypeId = userDetails.UserTypeId
            //    };
            //    return user;
            //}
            //else
            //{
            //    return userDetails;
            //}
        

        //public int RegisterUser(UserMaster userData)
        //{
        //    try
        //    {
        //        userData.UserTypeId = 2;
        //        _context.UserMaster.Add(userData);
        //        _context.SaveChanges();
        //        return 1;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        public bool CheckUserAvailabity(string userName)
        {
            string user = _context.UserMaster.FirstOrDefault(x => x.Username == userName)?.ToString();

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isUserExists(int userId)
        {
            string user = _context.UserMaster.FirstOrDefault(x => x.UserId == userId)?.ToString();

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       public UserMaster Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.UserMaster.SingleOrDefault(x => x.Username == username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        public IEnumerable<UserMaster> GetAll()
        {
            return _context.UserMaster;
        }

        public UserMaster GetById(int id)
        {
            return _context.UserMaster.Find(id);
        }

        public UserMaster RegisterUser(UserMaster user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_context.UserMaster.Any(x => x.Username == user.Username))
                throw new AppException("Username \"" + user.Username + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.UserMaster.Add(user);
            _context.SaveChanges();

            return user;
        }

        public void Update(UserMaster userParam, string password = null)
        {
            var user = _context.UserMaster.Find(userParam.UserId);

            if (user == null)
                throw new AppException("UserMaster not found");

            // update username if it has changed
            if (!string.IsNullOrWhiteSpace(userParam.Username) && userParam.Username != user.Username)
            {
                // throw error if the new username is already taken
                if (_context.UserMaster.Any(x => x.Username == userParam.Username))
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

            _context.UserMaster.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.UserMaster.Find(id);
            if (user != null)
            {
                _context.UserMaster.Remove(user);
                _context.SaveChanges();
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
    }
}
