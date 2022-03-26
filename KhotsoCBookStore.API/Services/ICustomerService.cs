using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomersAync();
        Task<Customer> GetCustomerByIdAsync(Guid customerId);        
        void DeleteCustomer(Guid customerId);
        Task<bool> CustomerIfExistsAsync(Guid customerId);
        Task CreateCustomerAsync(Customer newCustomer);
        bool CheckUserAvailabity(string customerName);
        void RegisterUser(Customer customer, string password);
        Task<bool> SaveChangesAsync();
        Task<bool> CheckIfCustomerExists(Guid customerId);
    }
}