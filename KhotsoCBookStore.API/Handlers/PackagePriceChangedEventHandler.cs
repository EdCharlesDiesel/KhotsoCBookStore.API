using DDD.ApplicationLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.Events;
using StarPeaceAdminHubDomain.IRepositories;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Handlers
{
    public class PackagePriceChangedEventHandler :
        IEventHandler<PackagePriceChangedEvent>
    {
        IPackageEventRepository repo;
        public PackagePriceChangedEventHandler(IPackageEventRepository repo)
        {
            this.repo = repo;
        }
        public Task HandleAsync(PackagePriceChangedEvent ev)
        {
         //   repo.New(PackageEventType.CostChanged, ev.PackageId, ev.OldVersion, ev.NewVersion, ev.NewPrice);
            return Task.CompletedTask;
        }
    }
}
