using AutoMapper;
using Restoraunt.Restoraunt.BL.Auth.Entities;
using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.Service.Controllers.Entities;

namespace Restoraunt.Restoraunt.BL.Auth;

public class UsersManager : IUsersManager
{
    private readonly IRepository<User> _usersRepository;
    private readonly IMapper _mapper;

    public UsersManager(IRepository<User> usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }

    public UserModel CreateUser(CreateUserRequest model)
    {
        var entity = _mapper.Map<User>(model);

        _usersRepository.Save(entity);

        return _mapper.Map<UserModel>(entity);
    }

    public UserModel UpdateUser(int id, UpdateUserRequest model)
    {
        var entity = _usersRepository.GetById(id);
        if (entity == null)
        {
            throw new ArgumentException("User not found.");
        }

        _mapper.Map(model, entity);

        _usersRepository.Save(entity);

        return _mapper.Map<UserModel>(entity);
    }

    public void DeleteUser(int id)
    {
        var entity = _usersRepository.GetById(id);
        if (entity == null)
        {
            throw new ArgumentException("User not found.");
        }

        _usersRepository.Delete(entity);
    }
}