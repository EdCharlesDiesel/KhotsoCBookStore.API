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
        void DeleteCustomer(Customer customerEntity);
        Task<bool> CustomerIfExistsAsync(Guid customerId);
        Task CreateCustomerAsync(Customer newCustomer);
        bool CheckUserAvailabity(string customerName);
        void RegisterUser(Customer customer, string password);
        Task SaveChangesAsync();
    }
}