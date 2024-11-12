using AutoMapper;
using Restoraunt.DataAccess.Migrations.Restoraunt.BL.FavoriteDishes;
using Restoraunt.DataAccess.Migrations.Restoraunt.BL.FavoriteDishes.Entities;
using Restoraunt.Restoraunt.BL.FavoriteDishes.Entities;
using Restoraunt.Restoraunt.DataAccess;

namespace Restoraunt.Restoraunt.BL.FavoriteDishes;

public class FavoriteDishManager : IFavoriteDishManager
{
    private readonly IRepository<FavoriteDish> _favoriteDishRepository;
    private readonly IMapper _mapper;

    public FavoriteDishManager(IRepository<FavoriteDish> favoriteDishRepository, IMapper mapper)
    {
        _favoriteDishRepository = favoriteDishRepository;
        _mapper = mapper;
    }

    public FavoriteDishModel CreateFavoriteDish(CreateFavoriteDishModel model)
    {
        var entity = _mapper.Map<FavoriteDish>(model);

        _favoriteDishRepository.Save(entity);

        return _mapper.Map<FavoriteDishModel>(entity);
    }

    public FavoriteDishModel UpdateFavoriteDish(int id, UpdateFavoriteDishModel model)
    {
        var entity = _favoriteDishRepository.GetById(id);
        if (entity == null)
        {
            throw new ArgumentException("Favorite Dish not found.");
        }

        _mapper.Map(model, entity);

        _favoriteDishRepository.Save(entity);

        return _mapper.Map<FavoriteDishModel>(entity);
    }

    public void DeleteFavoriteDish(int id)
    {
        var entity = _favoriteDishRepository.GetById(id);
        if (entity == null)
        {
            throw new ArgumentException("Favorite Dish not found.");
        }

        _favoriteDishRepository.Delete(entity);
    }
}
