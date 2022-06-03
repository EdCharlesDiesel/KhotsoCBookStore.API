using DDD.ApplicationLayer;
using KhotsoCBookStore.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Queries
{
    public interface ICustomersListQuery: IQuery
    {
        Task<IEnumerable<CustomerInfosViewModel>> GetAllCustomers();
        Task<CustomerInfosViewModel> GetCustomerById(int customerId);
    }
}
