using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("api1", "Full access to Meetup API"),
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new[]
            {
                new ApiResource("api1", "Meetup API") {Scopes = {"api1"}}
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                    {
                        ClientId = "meetup_api_swagger",
                        ClientName = "Meetup UI for demo_api",
                        ClientSecrets = {new Secret("secret".Sha256())},

                        AllowedGrantTypes = GrantTypes.Code,
                        RequirePkce = true,
                        RequireClientSecret = false,

                        RedirectUris = {"https://localhost:7100/swagger/oauth2-redirect.html"},
                        AllowedCorsOrigins = {"https://localhost:7100"},
                        AllowedScopes = {"api1"}
                    }
            };
    }
}