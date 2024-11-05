using AutoMapper;
using Restoraunt.Restoraunt.BL.Auth;
using Restoraunt.Restoraunt.BL.Auth.Entities;
using Restoraunt.Restoraunt.BL.Trainers.Entities;
using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.Service.Controllers.Entities;

public class AdminsProvider : IAdminsProvider
{
    private readonly IRepository<Admin> _adminsRepository;
    private readonly IMapper _mapper;

    public AdminsProvider(IRepository<Admin> adminsRepository, IMapper mapper)
    {
        _adminsRepository = adminsRepository;
        _mapper = mapper;
    }

    public IEnumerable<AdminModel> GetAdmins()
    {
        var admins = _adminsRepository.GetAll();
        return _mapper.Map<IEnumerable<AdminModel>>(admins);
    }

    public AdminModel GetAdminInfo(int id)
    {
        var admin = _adminsRepository.GetById(id);
        if (admin == null)
        {
            throw new ArgumentException("Admin not found.");
        }

        return _mapper.Map<AdminModel>(admin);
    }

    public IEnumerable<AdminModel> GetAdmins(AdminModelFilter filter)
    {
        var admins = _adminsRepository.GetAll();

        return _mapper.Map<IEnumerable<AdminModel>>(admins);
    }
}