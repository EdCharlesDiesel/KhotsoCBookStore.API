using IdentityModel.Client;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Services
{
    public interface IIdentityServer4Service
    {
        Task<TokenResponse> GetToken(string apiScope);
    }
}
