using AutoMapper;
using Restoraunt.Restoraunt.BL.Auth.Entities;
using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.Service.Controllers.Entities;

namespace Restoraunt.Restoraunt.BL.Auth;

public class MenusProvider : IMenusProvider
{
    private readonly IRepository<Menu> _menusRepository;
    private readonly IMapper _mapper;

    public MenusProvider(IRepository<Menu> menusRepository, IMapper mapper)
    {
        _menusRepository = menusRepository;
        _mapper = mapper;
    }

    public IEnumerable<MenuModel> GetMenus()
    {
        var menus = _menusRepository.GetAll();
        return _mapper.Map<IEnumerable<MenuModel>>(menus);
    }

    public MenuModel GetMenuInfo(int id)
    {
        var menu = _menusRepository.GetById(id);
        if (menu == null)
        {
            throw new ArgumentException("Menu not found.");
        }

        return _mapper.Map<MenuModel>(menu);
    }

    public IEnumerable<MenuModel> GetMenus(MenusFilter filter)
    {
        var menus = _menusRepository.GetAll();

        return _mapper.Map<IEnumerable<MenuModel>>(menus);
    }
}