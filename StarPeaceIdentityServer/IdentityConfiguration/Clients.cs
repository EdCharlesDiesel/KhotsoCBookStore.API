using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeaceIdentityServer.IdentityConfiguration
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "khotsoCBookStoreApi",
                    ClientName = "KhotsoCBookStore Api",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret> {new Secret("khotsoCBookStoreSecretKey".Sha256())},
                    AllowedScopes = new List<string> {"khotsoCBookStoreApi.read"}
                },
                new Client
                {
                    ClientId = "starPeaceAdmin",
                    ClientName = "StarPeace Admin Hub Web App",
                    ClientSecrets = new List<Secret> {new Secret("starPeaceAdminSecretKey".Sha256())},
    
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = new List<string> {"https://localhost:7001/signin-oidc"},
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "role",
                        "khotsoCBookStoreApi.read"
                    },

                    RequirePkce = true,
                    AllowPlainTextPkce = false
                }
            };
        }
    }
}
