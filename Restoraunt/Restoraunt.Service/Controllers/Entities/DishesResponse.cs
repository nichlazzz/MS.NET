using Restoraunt.Restoraunt.BL.Dishes.Entities;
using Restoraunt.Restoraunt.DataAccess;

namespace Restoraunt.Restoraunt.Service.Controllers.Entities;

public class DishesListResponse
{
    public List<DishModel> Dishes { get; set; }
}
