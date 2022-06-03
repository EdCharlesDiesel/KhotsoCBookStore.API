using DDD.DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public enum PackageEventType {Deleted}
    public interface IPackageEvent: IEntity<long>
    {
        PackageEventType Type { get; }
        int PackageId { get; }
        long? OldVersion { get;}
        long? NewVersion { get;}
    }
}
