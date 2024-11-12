using Restoraunt.DataAccess.Migrations.Restoraunt.BL.FavoriteDishes.Entities;
using Restoraunt.Restoraunt.DataAccess;

namespace Restoraunt.Restoraunt.Service.Controllers.Entities;

public class FavoriteDishesListResponse
{
    public List<FavoriteDishModel> FavoriteDishes { get; set; }
}
