
namespace DDD.DomainLayer
{
    public interface IRepository<T>: IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
