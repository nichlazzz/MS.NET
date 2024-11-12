using AutoMapper;
using Restoraunt.DataAccess.Migrations.Restoraunt.BL.FavoriteDishes;
using Restoraunt.DataAccess.Migrations.Restoraunt.BL.FavoriteDishes.Entities;
using Restoraunt.Restoraunt.BL.FavoriteDishes.Entities;
using Restoraunt.Restoraunt.DataAccess;

namespace Restoraunt.Restoraunt.BL.FavoriteDishes;


public class FavoriteDishProvider : IFavoriteDishProvider
{
    private readonly IRepository<FavoriteDish> _favoriteDishRepository;
    private readonly IMapper _mapper;

    public FavoriteDishProvider(IRepository<FavoriteDish> favoriteDishRepository, IMapper mapper)
    {
        _favoriteDishRepository = favoriteDishRepository;
        _mapper = mapper;
    }

    // Implemented methods:

    public IEnumerable<FavoriteDishModel> GetFavoriteDishes()
    {
        var favoriteDishes = _favoriteDishRepository.GetAll();
        return _mapper.Map<IEnumerable<FavoriteDishModel>>(favoriteDishes);
    }

    public FavoriteDishModel GetFavoriteDishInfo(int id)
    {
        var favoriteDish = _favoriteDishRepository.GetById(id);
        if (favoriteDish == null)
        {
            throw new ArgumentException("Favorite Dish not found.");
        }

        return _mapper.Map<FavoriteDishModel>(favoriteDish);
    }

    public IEnumerable<FavoriteDishModel> GetFavoriteDishes(FavoriteDishModelFilter filter)
    {
        // Assuming you don't have a GetByFilter method on _favoriteDishRepository
        // You might need to implement this method in your IRepository<FavoriteDish> implementation
        var favoriteDishes = _favoriteDishRepository.GetAll(); 
        return _mapper.Map<IEnumerable<FavoriteDishModel>>(favoriteDishes);
    }
}