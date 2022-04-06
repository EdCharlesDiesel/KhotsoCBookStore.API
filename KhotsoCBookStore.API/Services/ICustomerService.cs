using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Services
{
    public interface ICustomerService
    {
        Task CreateCustomerAsync(Customer newCustomer);

        Task<IEnumerable<Customer>> GetAllCustomersAync();

        Task<Customer> GetCustomerByIdAsync(Guid customerId);    

        Task UpdateCustomerAsync(Customer oldCustomerToUpdate);

        void DeleteCustomer(Customer customerToDelete);

        Task<bool> SaveChangesAsync();

        Task<bool> CustomerIfExistsAsync(Guid customerId);
        
        Task<bool> CheckUsernameAvailabity(string customerName);        
        
        Task<bool> CheckIfCustomerExists(Guid customerId);
    }
}