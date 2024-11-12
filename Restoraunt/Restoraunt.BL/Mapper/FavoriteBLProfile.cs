using AutoMapper;
using Restoraunt.DataAccess.Migrations.Restoraunt.BL.FavoriteDishes.Entities;
using Restoraunt.Restoraunt.DataAccess;

namespace Restoraunt.Restoraunt.BL.Mapper;

public class FavoriteDishBLProfile : Profile
{
    public FavoriteDishBLProfile()
    {
        // Map FavoriteDish to FavoriteDishModel
        CreateMap<FavoriteDish, FavoriteDishModel>()
            .ForMember(x => x.Description, y => y.MapFrom(src => src.Descroption)) // Assuming a typo in the entity property name
            .ForMember(x => x.IdUser, y => y.MapFrom(src => src.IdUser))
            .ForMember(x => x._User, y => y.MapFrom(src => src._User));

        // Map CreateFavoriteDishModel to FavoriteDish
        CreateMap<CreateFavoriteDishModel, FavoriteDish>()
            .ForMember(x => x.Id, y => y.Ignore())
            .ForMember(x => x.Descroption, y => y.MapFrom(src => src.Description)); // Assuming a typo in the model property name
    }
}

