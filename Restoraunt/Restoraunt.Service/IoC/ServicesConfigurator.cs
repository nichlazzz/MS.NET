using Restoraunt.DataAccess.Migrations.Restoraunt.BL.FavoriteDishes;
using Restoraunt.DataAccess.Migrations.Restoraunt.BL.FavoriteDishes.Entities;
using Restoraunt.DataAccess.Migrations.Restoraunt.BL.Orders;
using Restoraunt.DataAccess.Migrations.Restoraunt.BL.Orders.Entities;
using Restoraunt.Restoraunt.BL.Auth;
using Restoraunt.Restoraunt.BL.Dishes;
using Restoraunt.Restoraunt.BL.FavoriteDishes;
using Restoraunt.Restoraunt.BL.Orders;
using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.Service.Settings;

public static class ServicesConfigurator
{
    public static void ConfigureService(IServiceCollection services, RestorauntSettings settings)
    {
        // Register Generic Repository
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        // Register your specific providers and managers
        services.AddScoped<IAdminsProvider, AdminsProvider>();
        services.AddScoped<IOrderProvider, OrderProvider>();
        services.AddScoped<IFavoriteDishProvider, FavoriteDishProvider>();
        services.AddScoped<IDishProvider, DishProvider>();

        services.AddScoped<IAdminsManager, AdminsManager>();
        services.AddScoped<IOrderManager, OrderManager>();
        services.AddScoped<IFavoriteDishManager, FavoriteDishManager>();
        services.AddScoped<IDishManager, DishManager>();

        // Example: Register IAuthProvider (if needed)
        //services.AddScoped<IAuthProvider>(x =>
        //    new AuthProvider(x.GetRequiredService<SignInManager<UserEntity>>(),
        //        x.GetRequiredService<UserManager<UserEntity>>(),
        //        x.GetRequiredService<IHttpClientFactory>(),
        //        settings.IdentityServerUri,
        //        settings.ClientId,
        //        settings.ClientSecret));
    }
}