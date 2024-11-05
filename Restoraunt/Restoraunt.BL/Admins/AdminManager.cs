using AutoMapper;
using Restoraunt.Restoraunt.BL.Auth;
using Restoraunt.Restoraunt.BL.Trainers.Entities;
using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.Service.Controllers.Entities;

public class AdminsManager : IAdminsManager
{
    private readonly IRepository<Admin> _adminsRepository;
    private readonly IMapper _mapper;

    public AdminsManager(IRepository<Admin> adminsRepository, IMapper mapper)
    {
        _adminsRepository = adminsRepository;
        _mapper = mapper;
    }

    public AdminModel CreateAdmin(CreateAdminRequest model)
    {
        var entity = _mapper.Map<Admin>(model);

        _adminsRepository.Save(entity); 

        return _mapper.Map<AdminModel>(entity);
    }

    public AdminModel UpdateAdmin(int id, UpdateAdminRequest model)
    {
        var entity = _adminsRepository.GetById(id);
        if (entity == null)
        {
            throw new ArgumentException("Admin not found.");
        }

        _mapper.Map(model, entity); // Update entity properties from the model

        _adminsRepository.Save(entity);

        return _mapper.Map<AdminModel>(entity);
    }

    public void DeleteAdmin(int id)
    {
        var entity = _adminsRepository.GetById(id);
        if (entity == null)
        {
            throw new ArgumentException("Admin not found.");
        }

        _adminsRepository.Delete(entity);
    }
    
}
