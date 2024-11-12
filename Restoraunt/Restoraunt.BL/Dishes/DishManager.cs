using AutoMapper;
using Restoraunt.Restoraunt.BL.Dishes.Entities;
using Restoraunt.Restoraunt.DataAccess;

namespace Restoraunt.Restoraunt.BL.Dishes;

public class DishManager : IDishManager
{
    private readonly IRepository<Dish> _dishRepository;
    private readonly IMapper _mapper;

    public DishManager(IRepository<Dish> dishRepository, IMapper mapper)
    {
        _dishRepository = dishRepository;
        _mapper = mapper;
    }

    public DishModel CreateDish(CreateDishModel model)
    {
        var entity = _mapper.Map<Dish>(model);

        _dishRepository.Save(entity);

        return _mapper.Map<DishModel>(entity);
    }

    public DishModel UpdateDish(int id, UpdateDishModel model)
    {
        var entity = _dishRepository.GetById(id);

        if (entity == null)
        {
            throw new ArgumentException("Dish not found.");
        }

        _mapper.Map(model, entity);

        _dishRepository.Save(entity);

        return _mapper.Map<DishModel>(entity);
    }

    public void DeleteDish(int id)
    {
        var entity = _dishRepository.GetById(id);
        if (entity == null)
        {
            throw new ArgumentException("Dish not found.");
        }

        _dishRepository.Delete(entity);
    }
}
