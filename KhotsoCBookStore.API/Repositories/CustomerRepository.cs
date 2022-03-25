using KhotsoCBookStore.API.Contexts;
using KhotsoCBookStore.API.Dtos;
using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Repositories
{
    public class CustomerRepository : ICustomerService
    {
        private readonly KhotsoCBookStoreDbContext _dbContext;

        public CustomerRepository(KhotsoCBookStoreDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAync()
        {
            return await  _dbContext.Customers.OrderBy(c=>c.LastName).ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(Guid customerId)
        {
            return await _dbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }

        public async Task CreateCustomerAsync(Customer newCustomer)
        {
            if (newCustomer != null)
            {
               await _dbContext.AddAsync(newCustomer);
            }
        }

        public void DeleteCustomer(Guid customerId)
        {
            try
            {                
                var customer = _dbContext.Customers.Find(customerId);
                _dbContext.Customers.Remove(customer);               
            }
             catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _dbContext.SaveChangesAsync() >= 0);
        }


        ///<summary>
        ///ToDo: Work On Authrntication and Authorization.
        ///</summary>
        public int RegisterCustomer(CustomerForCreateDto newCustomer)
        {
            try
            {

                // userData.UserTypeId = 2;
                // _dbContext.Customer.Add(userData);
                // _dbContext.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public bool CheckUserAvailabity(string userName)
         {
        //     var username =  _dbContext.Customers
        //     .FirstOrDefault(c => c.Username == userName)?.ToString();

        //     if (username != null)
        //     {
        //         return true;
        //     }
        //     else
        //     {
        //         return false;
        //     }

            throw new NotImplementedException();
         }

        public bool isUserExists(Guid customerId)
        {
            string customer = _dbContext.Customers.FirstOrDefault(x => x.CustomerId == customerId)?.ToString();

            if (customer != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Customer Authenticate(string username, string password)
        {
            // if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            //     return null;

            // var user = _dbContext.Customers.SingleOrDefault(x => x.Username == username);

            // // check if username exists
            // if (user == null)
            //     return null;

            // // check if password is correct
            // if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            //     return null;

            // // authentication successful
            // return user;

            throw new NotImplementedException();
        }


      

        public Customer RegisterCustomer(Customer customer, string password)
        {
            // // validation
            // if (string.IsNullOrWhiteSpace(password))
            //     throw new AppException("Password is required");

            // if (_dbContext.Customers.Any(x => x.Username == customer.Username))
            //     throw new AppException("Username \"" + customer.Username + "\" is already taken");

            // byte[] passwordHash, passwordSalt;
            // CreatePasswordHash(password, out passwordHash, out passwordSalt);

            // customer.PasswordHash = passwordHash;
            // customer.PasswordSalt = passwordSalt;

            // _dbContext.Customers.Add(customer);
            // _dbContext.SaveChanges();

            // return customer;

             throw new NotImplementedException();
        }

        public void Update(Customer userParam, string password = null)
        {
            // var user = _dbContext.Customers.Find(userParam.CustomerId);

            // if (user == null)
            //     throw new AppException("Customer not found");

            // // update username if it has changed
            // if (!string.IsNullOrWhiteSpace(userParam.Username) && userParam.Username != user.Username)
            // {
            //     // throw error if the new username is already taken
            //     if (_dbContext.Customers.Any(x => x.Username == userParam.Username))
            //         throw new AppException("Username " + userParam.Username + " is already taken");

            //     user.Username = userParam.Username;
            // }

            // // update user properties if provided
            // if (!string.IsNullOrWhiteSpace(userParam.FirstName))
            //     user.FirstName = userParam.FirstName;

            // if (!string.IsNullOrWhiteSpace(userParam.LastName))
            //     user.LastName = userParam.LastName;

            // if (!string.IsNullOrWhiteSpace(userParam.EmailAddress))
            //     user.EmailAddress = userParam.EmailAddress;

            // // update password if provided
            // if (!string.IsNullOrWhiteSpace(password))
            // {
            //     byte[] passwordHash, passwordSalt;
            //     CreatePasswordHash(password, out passwordHash, out passwordSalt);

            //     user.PasswordHash = passwordHash;
            //     user.PasswordSalt = passwordSalt;
            // }

            // _dbContext.Customers.Update(user);
            // _dbContext.SaveChanges();

             throw new NotImplementedException();
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

       

    

     

   

        public Task<bool> CustomerIfExistsAsync(Guid customerId)
        {
            throw new NotImplementedException();
        }

    

        public void RegisterUser(CustomerDto customer, object password)
        {
            throw new NotImplementedException();
        }

       

     

        public void RegisterUser(CustomerDto customer, string password)
        {
            throw new NotImplementedException();
        }

        

        public Task GetCustomerAsync(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public void RegisterUser(Customer customer, string password)
        {
            throw new NotImplementedException();
        }

        // Task<Customer> ICustomerService.GetCustomerAsync(Guid customerId)
        // {
        //     throw new NotImplementedException();
        // }

      
    }
}
