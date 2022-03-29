using System;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Services
{
    public interface IWishListService
    {
        Task CreateWishListAsync(Guid customerId);

        Task AddBookToWishListAsync(Guid customerId, Guid bookId);

        Task<string> GetWishListIdAsync(Guid customerId);

        Task<int> GetWishListItemsCount(Guid customerId);

        Task UpdateWishListItems(Guid customerId);        
        
        Task DeleteOneWishListItem(Guid customerId, Guid bookId);       
       
        Task<int> ClearWishList(Guid customerId);

        Task<bool> SaveChangesAsync();
    }
}
