using AutoMapper;
using Restoraunt.Restoraunt.BL.Dishes.Entities;
using Restoraunt.Restoraunt.DataAccess;

namespace Restoraunt.Restoraunt.BL.Dishes;

public class DishProvider : IDishProvider
{
    private readonly IRepository<Dish> _dishRepository;
    private readonly IMapper _mapper;

    public DishProvider(IRepository<Dish> dishRepository, IMapper mapper)
    {
        _dishRepository = dishRepository;
        _mapper = mapper;
    }

    public IEnumerable<DishModel> GetDishes()
    {
        var dishes = _dishRepository.GetAll();
        return _mapper.Map<IEnumerable<DishModel>>(dishes);
    }

    public DishModel GetDishInfo(int id)
    {
        var dish = _dishRepository.GetById(id);
        if (dish == null)
        {
            throw new ArgumentException("Dish not found.");
        }

        return _mapper.Map<DishModel>(dish);
    }

    public IEnumerable<DishModel> GetDishes(DishModelFilter filter)
    {
        var dishes = _dishRepository.GetAll(); // Assuming GetByFilter is not implemented
        return _mapper.Map<IEnumerable<DishModel>>(dishes);
    }
}
