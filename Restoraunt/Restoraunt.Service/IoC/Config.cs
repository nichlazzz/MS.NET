using Duende.IdentityServer.Models;

namespace Restoraunt.Restoraunt.Service.IoC;

public static class Config
{
    public static IEnumerable<IdentityResource> Ids =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email()
        };

    public static IEnumerable<ApiScope> Apis =>
        new ApiScope[]
        {
            new ApiScope("api1", "My API")
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            // client credentials client
            new Client
            {
                ClientId = "client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedScopes = { "api1" }
            },
            // interactive client using code flow + pkce
            new Client
            {
                ClientId = "interactive",
                ClientSecrets = { new Secret("secret".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = { "https://localhost:5001/signin-oidc" }, // Replace with your redirect URI
                FrontChannelLogoutUri = "https://localhost:5001/signout-oidc", // Replace with your logout URI
                PostLogoutRedirectUris = { "https://localhost:5001/signout-callback-oidc" }, // Replace with your logout URI
                AllowedScopes = { "openid", "profile", "api1" }
            }
        };
}
