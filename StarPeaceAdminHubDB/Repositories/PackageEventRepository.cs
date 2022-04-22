using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StarPeaceAdminHubDB.Models;

namespace StarPeaceAdminHubDB.Repositories
{
    public class PackageEventRepository : IPackageEventRepository
    {
        private MainDbContext context;
        public PackageEventRepository(MainDbContext context)
        {
            this.context = context;
        }
        public IUnitOfWork UnitOfWork => context;

        public async Task<IEnumerable<IPackageEvent>> GetFirstN(int n)
        {
            return await context.PackageEvents
                .OrderBy(m => m.Id)
                .Take(n)
                .ToListAsync();
        }

        public IPackageEvent New(PackageEventType type, int id, long oldVersion, long? newVersion=null, decimal price=0)
        {
            var model = new PackageEvent
            {
                Type = type,
                PackageId = id,
                OldVersion = oldVersion,
                NewVersion = newVersion,
                NewPrice = price
            };
            context.PackageEvents.Add(model);
            return model;
        }
    }
}
