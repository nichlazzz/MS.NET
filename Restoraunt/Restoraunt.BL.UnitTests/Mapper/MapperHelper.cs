using AutoMapper;
using Restoraunt.Restoraunt.BL.Mapper;

namespace Restoraunt.Restoraunt.BL.UnitTests.Mapper;

public static class MapperHelper
{
    static MapperHelper()
    {
        // Create the MapperConfiguration with your profiles
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AdminBLProfile>(); 
            cfg.AddProfile<OrderBLProfile>(); 
            cfg.AddProfile<FavoriteDishBLProfile>();
            cfg.AddProfile<DishBLProfile>(); 
            // ... add other profiles 
        });

        // Create the Mapper instance
        Mapper = new AutoMapper.Mapper(config);
    }

    public static IMapper Mapper { get; } 
}
