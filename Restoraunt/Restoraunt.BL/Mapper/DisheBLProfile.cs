using System.Data.SqlTypes;
using AutoMapper;
using Restoraunt.Restoraunt.BL.Dishes.Entities;
using Restoraunt.Restoraunt.DataAccess;

namespace Restoraunt.Restoraunt.BL.Mapper;

public class DishBLProfile : Profile
{
    public DishBLProfile()
    {
        // Map Dish to DishModel
        CreateMap<Dish, DishModel>()
            .ForMember(x => x.Cost, y => y.MapFrom(src => src.Cost.Value)) // Map SqlMoney to decimal
            .ForMember(x => x.Image, y => y.MapFrom(src => src.Image)); // Assuming you handle Image differently

        // Map CreateDishModel to Dish
        CreateMap<CreateDishModel, Dish>()
            .ForMember(x => x.Id, y => y.Ignore())
            .ForMember(x => x.Cost, y => y.MapFrom(src => new SqlMoney(src.Cost))); // Map decimal back to SqlMoney
    }
}
