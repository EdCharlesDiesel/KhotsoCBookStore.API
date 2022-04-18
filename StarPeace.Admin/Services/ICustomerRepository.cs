using StarPeace.Admin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Admin.Services
{
    public interface ICustomerRepository
    {
        List<Customer> SelectAll();
        Customer SelectByID(string id);
        void Insert(Customer obj);
        void Update(Customer obj);
        void Delete(string id);
        void Save();
    }

    public interface IRepository<T1,T2> where T1:class
    {
        List<T1> SelectAll();
        T1 SelectByID(T2 id);
        void Insert(T1 obj);
        void Update(T1 obj);
        void Delete(T2 id);
        void Save();
    }
}
