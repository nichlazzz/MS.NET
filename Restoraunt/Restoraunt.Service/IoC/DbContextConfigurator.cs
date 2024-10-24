using Microsoft.EntityFrameworkCore;
using Restoraunt.Restoraunt.DataAccess;

namespace Restoraunt.Restoraunt.Service.IoC;

public static class DbContextConfigurator
{
    public static void ConfigureApplication(IApplicationBuilder app)
    {
        
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<RestorauntDbContext>>();
        using var context = contextFactory.CreateDbContext();
    }
}