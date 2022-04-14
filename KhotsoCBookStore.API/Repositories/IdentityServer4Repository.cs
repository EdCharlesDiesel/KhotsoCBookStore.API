using IdentityModel.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Repositories
{
    public class IdentityServer4Repository : IIdentityServer4Service

    {
        private DiscoveryDocumentResponse _discoveryDocument { get; set; }
        public IdentityServer4Repository()
        {
            using (var client = new HttpClient())
            {
                _discoveryDocument = client.GetDiscoveryDocumentAsync("https://localhost:8001/.well-known/openid-configuration").Result;
            }
        }
        public async Task<TokenResponse> GetToken(string apiScope)
        {
            using (var client = new HttpClient())
            {
                var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = _discoveryDocument.TokenEndpoint,
                    ClientId = "khotsoCBookStoreApi",
                    Scope = apiScope,
                    //! Need to use secret and remove the file from from github net time I push.
                    ClientSecret = "ProCodeGuide"
                });
                if (tokenResponse.IsError)
                {
                    throw new Exception("Token Error");
                }
                return tokenResponse;
            }
        }
    }
}
