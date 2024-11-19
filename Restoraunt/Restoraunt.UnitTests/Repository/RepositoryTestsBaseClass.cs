
using Microsoft.EntityFrameworkCore;
using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.Service.Settings;

namespace Restoraunt.Restoraunt.UnitTests.Repository;

public class RepositoryTestsBaseClass
{
    public RepositoryTestsBaseClass()
    {
        
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Test.json", optional: true)
            .Build();

        Settings = RestorauntSettingsReader.Read(configuration);
        ServiceProvider = ConfigureServiceProvider();

        DbContextFactory = ServiceProvider.GetRequiredService<IDbContextFactory<RestorauntDbContext>>();        
    }

    private IServiceProvider ConfigureServiceProvider()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDbContextFactory<RestorauntDbContext>(
            options => { options.UseSqlServer(Settings.RestorauntDbContextConnectionString); },
            ServiceLifetime.Scoped);
        return serviceCollection.BuildServiceProvider();
    }

    protected readonly RestorauntSettings Settings;
    protected readonly IDbContextFactory<RestorauntDbContext> DbContextFactory;
    protected readonly IServiceProvider ServiceProvider;
}