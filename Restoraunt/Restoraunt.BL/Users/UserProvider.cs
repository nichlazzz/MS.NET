using AutoMapper;
using Restoraunt.Restoraunt.BL.Auth.Entities;
using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.Service.Controllers.Entities;
using UsersFilter = Restoraunt.Restoraunt.BL.Users.Entities.UsersFilter;

namespace Restoraunt.Restoraunt.BL.Auth;

public class UsersProvider : IUserProvider
{
    private readonly IRepository<User> _usersRepository;
    private readonly IMapper _mapper;

    public UsersProvider(IRepository<User> usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }

    public IEnumerable<UserModel> GetUsers()
    {
        var users = _usersRepository.GetAll();
        return _mapper.Map<IEnumerable<UserModel>>(users);
    }

    public UserModel GetUserInfo(int id)
    {
        var user = _usersRepository.GetById(id);
        if (user == null)
        {
            throw new ArgumentException("User not found.");
        }

        return _mapper.Map<UserModel>(user);
    }

    public IEnumerable<UserModel> GetUsers(UsersFilter filter)
    {
        var users = _usersRepository.GetAll(); // Add other filter conditions

        return _mapper.Map<IEnumerable<UserModel>>(users);
    }
}