using IdentityServer4.Models;
using System.Collections.Generic;

namespace StarPeace.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new[]
            {
                new ApiScope("khotsoCBookStoreApi", "Full access to API #1") // "full access" scope
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new[]
            {
                new ApiResource("khotsoCBookStoreApi", "API #1") {Scopes = {"khotsoCBookStoreApi"}}
            };

        public static IEnumerable<Client> Clients =>
            new[]
            {
                // Swashbuckle & NSwag
                new Client
                {
                    ClientId = "khotsoCBookStoreApi",
                    ClientName = "Swagger UI for KhotsoCBookStore Api",
                    ClientSecrets = {new Secret("secret".Sha256())}, // change me!
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = { "openid", "profile", "email", "api.read" },
                    RequirePkce = true,
                    RequireClientSecret = false,
                    RedirectUris = {"https://localhost:5001/swagger/oauth2-redirect.html"},
                    AllowedCorsOrigins = {"https://localhost:5000"},
                    AllowedScopes = {"khotsoCBookStoreApi"}

                }
            };
    }
}