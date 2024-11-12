using Microsoft.EntityFrameworkCore;
using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.Service.Settings;

namespace Restoraunt.Restoraunt.Service.IoC;

public static class DbContextConfigurator
{
    public static void ConfigureService(IServiceCollection services, RestorauntSettings settings)
    {
        // Configure your database connection
        services.AddDbContext<RestorauntDbContext>(options =>
            options.UseSqlServer(settings.IdentityServerUri));

        // Register the DbContextFactory
        services.AddDbContextFactory<RestorauntDbContext>();
    }

    // Existing method for configuring application
    public static void ConfigureApplication(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<RestorauntDbContext>>();
        using var context = contextFactory.CreateDbContext();
    }
}
