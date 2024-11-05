using AutoMapper;
using Restoraunt.Restoraunt.BL.Trainers.Entities;
using Restoraunt.Restoraunt.DataAccess;

namespace FitnessClub.BL.Mapper;

public class AdminBLProfile : Profile
{
    public AdminBLProfile()
    {
        CreateMap<Admin, AdminModel>()
            .ForMember(x => x.Id, y => y.MapFrom(src => src.ExternalId))
            .ForMember(x => x.FullName, y => y.MapFrom(src => $"{src.Name}"));

        CreateMap<CreateAdminModel, Admin>()
            .ForMember(x => x.Id, y => y.Ignore())
            .ForMember(x => x.ExternalId, y => y.Ignore())
            .ForMember(x => x.ModificationTime, y => y.Ignore())
            .ForMember(x => x.CreationTime, y => y.Ignore());
    }
}