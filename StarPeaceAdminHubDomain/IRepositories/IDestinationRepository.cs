using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDomain.IRepositories
{
    public interface IDestinationRepository:IRepository<IDestination>
    {
        Task<IDestination> Get(int id);
        IDestination New();
    }
}
