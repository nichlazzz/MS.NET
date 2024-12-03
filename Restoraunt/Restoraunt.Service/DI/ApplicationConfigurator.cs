using Restoraunt.Restoraunt.Service.IoC;
using Restoraunt.Restoraunt.Service.Settings;

namespace Restoraunt.Restoraunt.Service.DI;

public static class ApplicationConfigurator
{
    public static void ConfigureServices(WebApplicationBuilder builder, RestorauntSettings settings)
    {
        AuthorizationConfigurator.ConfigureServices(builder.Services, settings);
        DbContextConfigurator.ConfigureService(builder.Services, settings);
        SerilogConfigurator.ConfigureService(builder);
        SwaggerConfigurator.ConfigureServices(builder.Services);
        MapperConfigurator.ConfigureServices(builder.Services);
        ServicesConfigurator.ConfigureService(builder.Services, settings);

        builder.Services.AddControllers();
    }

    public static void ConfigureApplication(WebApplication app)
    {
        AuthorizationConfigurator.ConfigureApplication(app);
        SerilogConfigurator.ConfigureApplication(app);
        SwaggerConfigurator.ConfigureApplication(app);
        DbContextConfigurator.ConfigureApplication(app);

        app.MapControllers();
    }
}