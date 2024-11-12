using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.Service.Settings;

namespace Restoraunt.Restoraunt.Service.IoC;

public static class AuthorizationConfigurator
{
    public static void ConfigureServices(this IServiceCollection services, RestorauntSettings settings)
    {
        // Enable PII in IdentityModelEventSource for debugging
        IdentityModelEventSource.ShowPII = true;

        // Configure Identity for your User and Role entities
        services.AddIdentity<User, User>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireUppercase = true;
        })
        .AddEntityFrameworkStores<RestorauntDbContext>()
        .AddSignInManager<SignInManager<User>>()
        .AddDefaultTokenProviders();

        // Configure IdentityServer
        services.AddIdentityServer()
            .AddInMemoryApiScopes(new[] { new ApiScope("api") }) // Define your API scope(s)
            .AddInMemoryClients(new[] 
            {
                new Client
                {
                    ClientName = settings.ClientId, // Your client name
                    ClientId = settings.ClientId, // Your client ID
                    Enabled = true,
                    AllowOfflineAccess = true, 
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials, // Allow resource owner password and client credentials grant types
                    ClientSecrets = { new Secret(settings.ClientSecret.Sha256()) },
                    AllowedScopes = { "api" } // Grant access to the "api" scope
                }
            })
            .AddAspNetIdentity<User>();

        // Configure JWT Bearer Authentication
        services.AddAuthentication(options =>
        {
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
        {
            // Configure JWT Bearer Authentication
            options.RequireHttpsMetadata = false; // Enable or disable HTTPS validation
            options.Authority = settings.IdentityServerUri; // Your IdentityServer URI 
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = false, // Set to true if you have a signing key
                ValidateIssuer = false, // Set to true if you have an issuer
                ValidateAudience = false, // Set to true if you have an audience
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
            options.Audience = "api"; // Your API resource name
        });

        // Add Authorization
        services.AddAuthorization();
    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        // Use IdentityServer middleware
        app.UseIdentityServer(); 
        app.UseAuthentication();
        app.UseAuthorization();
    }
}