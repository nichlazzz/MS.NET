using AutoMapper;
using Restoraunt.Restoraunt.BL.Auth.Entities;
using Restoraunt.Restoraunt.DataAccess;

namespace Restoraunt.Restoraunt.BL.Mapper;

public class MenuBLProfile : Profile
{
    public MenuBLProfile()
    {
        CreateMap<Menu, MenuModel>()
            .ForMember(x => x.Id, y => y.MapFrom(src => src.ExternalId))
            .ForMember(x => x.IdDish, y => y.MapFrom(src => src.IdDish))
            .ForMember(x => x.IdAdmin, y => y.MapFrom(src => src.IdAdmin));

        CreateMap<CreateMenuModel, Menu>()
            .ForMember(x => x.Id, y => y.Ignore())
            .ForMember(x => x.ExternalId, y => y.Ignore())
            .ForMember(x => x.ModificationTime, y => y.Ignore())
            .ForMember(x => x.CreationTime, y => y.Ignore());
    }
}