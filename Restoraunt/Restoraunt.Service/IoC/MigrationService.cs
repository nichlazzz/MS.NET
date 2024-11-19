using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using Microsoft.EntityFrameworkCore;
using Restoraunt.Restoraunt.DataAccess;

namespace Restoraunt.Restoraunt.Service.IoC;

public class MigrationService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public MigrationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();

        var services = scope.ServiceProvider;

        // Migrate all the necessary DbContexts
        var configurationDbContext = services.GetRequiredService<ConfigurationDbContext>();
        await configurationDbContext.Database.MigrateAsync(cancellationToken);

        var persistedGrantDbContext = services.GetRequiredService<PersistedGrantDbContext>();
        await persistedGrantDbContext.Database.MigrateAsync(cancellationToken);

        var restaurantDbContext = services.GetRequiredService<RestorauntDbContext>();
        await restaurantDbContext.Database.MigrateAsync(cancellationToken);


        // Seed IdentityServer data (if needed)
        //  Note: This is very insecure, and should only be done in development.  Remove in production.
        await SeedIdentityServerDataAsync(configurationDbContext, cancellationToken);
    }


    public Task StopAsync(CancellationToken cancellationToken)
    {
        // No cleanup needed for this service
        return Task.CompletedTask;
    }


    // This method performs insecure seeding of IdentityServer data.  It should not be used in production.
    private async Task SeedIdentityServerDataAsync(ConfigurationDbContext context, CancellationToken cancellationToken)
    {
        // Check if data exists.
        if (!context.Clients.Any() && !context.IdentityResources.Any() && !context.ApiScopes.Any())
        {
            await context.AddRangeAsync(Config.Ids.Select(x => x.ToEntity()), cancellationToken);
            await context.AddRangeAsync(Config.Apis.Select(x => x.ToEntity()), cancellationToken);
            await context.AddRangeAsync(Config.Clients.Select(x => x.ToEntity()), cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}