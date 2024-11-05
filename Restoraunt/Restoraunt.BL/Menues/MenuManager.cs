using AutoMapper;
using Restoraunt.Restoraunt.BL.Auth.Entities;
using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.Service.Controllers.Entities;

namespace Restoraunt.Restoraunt.BL.Auth;

public class MenusManager : IMenusManager
{
    private readonly IRepository<Menu> _menusRepository;
    private readonly IMapper _mapper;

    public MenusManager(IRepository<Menu> menusRepository, IMapper mapper)
    {
        _menusRepository = menusRepository;
        _mapper = mapper;
    }

    public MenuModel CreateMenu(CreateMenuModel model)
    {
        var entity = _mapper.Map<Menu>(model);

        _menusRepository.Save(entity);

        return _mapper.Map<MenuModel>(entity);
    }

    public MenuModel UpdateMenu(int id, UpdateMenuModel model)
    {
        var entity = _menusRepository.GetById(id);
        if (entity == null)
        {
            throw new ArgumentException("Menu not found.");
        }

        _mapper.Map(model, entity);

        _menusRepository.Save(entity);

        return _mapper.Map<MenuModel>(entity);
    }

    public void DeleteMenu(int id)
    {
        var entity = _menusRepository.GetById(id);
        if (entity == null)
        {
            throw new ArgumentException("Menu not found.");
        }

        _menusRepository.Delete(entity);
    }
}