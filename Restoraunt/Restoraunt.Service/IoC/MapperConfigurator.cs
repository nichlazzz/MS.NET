using Restoraunt.Restoraunt.BL.Mapper;

namespace Restoraunt.Restoraunt.Service.IoC;

public static class MapperConfigurator
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile<AdminBLProfile>();
            config.AddProfile<OrderBLProfile>();
            config.AddProfile<FavoriteDishBLProfile>();
            config.AddProfile<DishBLProfile>();
        });
    }
}
