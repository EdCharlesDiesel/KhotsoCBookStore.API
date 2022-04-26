using DDD.DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public interface ICategory: IEntity<Guid>
    {
        void FullUpdate(ICategory o);
        string Name { get; }
        string Country { get;}
        string Description { get;}        
    }
}
