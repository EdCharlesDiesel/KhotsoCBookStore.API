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
                new ApiScope("api1", "Full access to API #1") // "full access" scope
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new[]
            {
                new ApiResource("api1", "API #1") {Scopes = {"api1"}}
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

                    //   RequireConsent = false,
                    // ClientId = "angular_spa",
                    // ClientName = "Angular SPA",
                    // AllowedGrantTypes = GrantTypes.Implicit,
                    // AllowedScopes = { "openid", "profile", "email", "api.read" },
                    // RedirectUris = {"http://localhost:4200/auth-callback"},
                    // PostLogoutRedirectUris = {"http://localhost:4200/"},
                    // AllowedCorsOrigins = {"http://localhost:4200"},
                    // AllowAccessTokensViaBrowser = true,
                    // AccessTokenLifetime = 3600
                }
            };
    }
}