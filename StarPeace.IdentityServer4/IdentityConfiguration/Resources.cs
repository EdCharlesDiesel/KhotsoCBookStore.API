using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.IdentityServer4.IdentityConfiguration
{
    public class Resources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new List<string> {"role"}
                },
                new IdentityResource
                {
                    Name = "administrator",
                    UserClaims = new List<string> {"administrator"}
                }                ,
                new IdentityResource
                {
                    Name = "developer",
                    UserClaims = new List<string> {"developer"}
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource
                {
                    Name = "khotsoCBookStoreApi",
                    DisplayName = "KhotsoCBookStore Api",
                    Description = "Allow the application to access KhotsoCBookStore Api on your behalf",
                    Scopes = new List<string> { "khotsoCBookStoreApi.read", "khotsoCBookStoreApi.write"},
                    ApiSecrets = new List<Secret> {new Secret("ProCodeGuide".Sha256())},
                    UserClaims = new List<string> {"role"}
                }
            };
        }
    }
}
