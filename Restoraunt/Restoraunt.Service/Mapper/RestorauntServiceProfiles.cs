using Restoraunt.Restoraunt.BL.Auth.Entities;
using Restoraunt.Restoraunt.Service.Controllers.Entities;
using AutoMapper;
using Restoraunt.DataAccess.Migrations.Restoraunt.BL.Orders.Entities;
using Restoraunt.Restoraunt.BL.Dishes.Entities;
using Restoraunt.Restoraunt.BL.FavoriteDishes.Entities;
using Restoraunt.Restoraunt.BL.Orders.Entities;
using Restoraunt.Restoraunt.BL.Trainers.Entities;
using Restoraunt.Restoraunt.DataAccess;
using AdminsModelFilter = Restoraunt.Restoraunt.BL.Auth.Entities.AdminModelFilter;
using MenusFilter = Restoraunt.Restoraunt.BL.Menues.Entities.MenusFilter;
using UsersFilter = Restoraunt.Restoraunt.BL.Users.Entities.UsersFilter;

namespace Restoraunt.Restoraunt.Service.Mapper;

public class RestorauntServiceProfiles:Profile
{
    public RestorauntServiceProfiles()
    {
        // Admin
        CreateMap<AdminsModelFilter, AdminsModelFilter>();
        CreateMap<CreateAdminRequest, AdminModel>();
        CreateMap<UpdateAdminRequest, UpdateAdminModel>();

        // Dish
        CreateMap<DishesFilter, DishModelFilter>();
        CreateMap<CreateDishRequest, Dish>();
        CreateMap<UpdateDishRequest, UpdateDishModel>();

        // FavoriteDish
        CreateMap<FavoriteDishesFilter, FavoriteDishModelFilter>();
        CreateMap<CreateFavoriteDishRequest, FavoriteDish>();
        CreateMap<UpdateFavoriteDishRequest, UpdateFavoriteDishModel>();

        // Menu
        CreateMap<MenusFilter, MenusModelFilter>();
        CreateMap<CreateMenuRequest, Menu>();
        CreateMap<UpdateMenuRequest, UpdateMenuModel>();

        // Order
        CreateMap<OrdersFilter, OrderModelFilter>();
        CreateMap<CreateOrderRequest, Order>();
        CreateMap<UpdateOrderRequest, UpdateOrderModel>();

        // User
        CreateMap<UsersFilter, UserModelFilter>();
        CreateMap<CreateUserRequest, User>();
        CreateMap<UpdateUserRequest, UpdateUserModel>();
    }
}