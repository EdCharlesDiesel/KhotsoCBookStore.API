﻿using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDomain.IRepositories
{
    public interface IBookRepository : IRepository<IBook>
    {
        Task<IBook> Get(int id);
        IBook New();        
    }
}
