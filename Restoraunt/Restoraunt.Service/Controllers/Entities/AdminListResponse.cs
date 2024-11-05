using Restoraunt.Restoraunt.BL.Trainers.Entities;
using Restoraunt.Restoraunt.DataAccess;

namespace Restoraunt.Restoraunt.Service.Controllers.Entities;

public class AdminsListResponse
{
    public List<AdminModel> Admins { get; set; }
}
