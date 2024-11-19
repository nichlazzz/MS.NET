using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.Service.IoC;

public static class IdentityServerConfig
{
    public static void AddIdentityServer(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("RestorauntDbContext"); //From appsettings.json

        // Add DbContexts
        services.AddDbContext<ConfigurationDbContext>(options =>
            options.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(typeof(RestorauntDbContext).Assembly.FullName)));

        services.AddDbContext<PersistedGrantDbContext>(options =>
            options.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(typeof(RestorauntDbContext).Assembly.FullName)));

        services.AddDbContext<RestorauntDbContext>(options =>
            options.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(typeof(RestorauntDbContext).Assembly.FullName)));

        // Add Identity
        services.AddIdentity<User, IdentityRole<int>>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 6;
        })
        .AddEntityFrameworkStores<RestorauntDbContext>()
        .AddDefaultTokenProviders();

        // Add IdentityServer
        var builder = services.AddIdentityServer(options =>
        {
            // IIS settings.
            options.IssuerUri = "https://your-issuer-uri"; // Replace with your actual issuer URI.  Important for production!
            options.Events.RaiseErrorEvents = true;
            options.Events.RaiseInformationEvents = true;
            options.Events.RaiseFailureEvents = true;
            options.Events.RaiseSuccessEvents = true;
        })
        .AddConfigurationStore(options =>
        {
            options.ConfigureDbContext = b => b.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(typeof(RestorauntDbContext).Assembly.FullName));
        })
        .AddOperationalStore(options =>        {
            options.ConfigureDbContext = b => b.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(typeof(RestorauntDbContext).Assembly.FullName));
        })
        .AddAspNetIdentity<User>() //Use your custom User class
        .AddInMemoryIdentityResources(Config.Ids)
        .AddInMemoryApiScopes(Config.Apis)
        .AddInMemoryClients(Config.Clients);


        services.AddTransient<IPersistedGrantDbContext, PersistedGrantDbContext>();
        services.AddHostedService<MigrationService>(); //Seed database
    }
}
