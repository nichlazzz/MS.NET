using AutoMapper;
using Restoraunt.Restoraunt.BL.Auth.Entities;
using Restoraunt.Restoraunt.DataAccess;

namespace FitnessClub.BL.Mapper;

public class UserBLProfile : Profile
{
    public UserBLProfile()
    {
        CreateMap<User, UserModel>()
            .ForMember(x => x.Id, y => y.MapFrom(src => src.ExternalId))
            .ForMember(x => x.Name, y => y.MapFrom(src => src.Name));

        CreateMap<CreateUserModel, User>()
            .ForMember(x => x.Id, y => y.Ignore())
            .ForMember(x => x.ExternalId, y => y.Ignore())
            .ForMember(x => x.ModificationTime, y => y.Ignore())
            .ForMember(x => x.CreationTime, y => y.Ignore());
    }
}