using System;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Dtos;

namespace KhotsoCBookStore.API.Services
{
    internal interface ICustomerService
    {
        Task GetAllCustomersAync();
        Task GetCustomerAsync(Guid customerId);
        Task SaveChangesAsync();
        void DeleteCustomer(object customerEntity);
        Task<bool> CustomerIfExistsAsync(Guid customerId);
        Task CreateCustomerAsync(CustomerForCreateDto newCustomer);
        bool CheckUserAvailabity(string customerName);
        void RegisterUser(CustomerDto customer, object password);
    }
}