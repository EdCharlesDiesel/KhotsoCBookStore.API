using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.Events;
using StarPeaceAdminHubDomain.IRepositories;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Handlers
{
    public class PackageDeleteEventHandler :
        IEventHandler<PackageDeleteEvent>
    {
        IPackageEventRepository repo;
        public PackageDeleteEventHandler(IPackageEventRepository repo)
        {
            this.repo = repo;
        }
        public Task HandleAsync(PackageDeleteEvent ev)
        {
            repo.New(PackageEventType.Deleted, ev.PackageId, ev.OldVersion);
            return Task.CompletedTask;
        }
    }
}
