using Restoraunt.Restoraunt.BL.Auth.Entities;
using Restoraunt.Restoraunt.Service.Controllers.Entities;
using AutoMapper;
using Restoraunt.Restoraunt.BL.Trainers.Entities;
using Restoraunt.Restoraunt.DataAccess;
using AdminsModelFilter = Restoraunt.Restoraunt.BL.Auth.Entities.AdminModelFilter;

namespace Restoraunt.Restoraunt.Service.Mapper;

public class RestorauntServiceProfile:Profile
{
    public RestorauntServiceProfile()
    {
        // Admin
        CreateMap<AdminsModelFilter, AdminsModelFilter>();
        CreateMap<CreateAdminRequest, AdminModel>();
        CreateMap<UpdateAdminRequest, UpdateAdminModel>();

        // Dish
        CreateMap<DishesFilter, DishesModelFilter>();
        CreateMap<CreateDishRequest, Dish>();
        CreateMap<UpdateDishRequest, UpdateDishModel>();

        // FavoriteDish
        CreateMap<FavoriteDishesFilter, FavoriteDishesModelFilter>();
        CreateMap<CreateFavoriteDishRequest, FavoriteDish>();
        CreateMap<UpdateFavoriteDishRequest, UpdateFavoriteDishModel>();

        // Menu
        CreateMap<MenusFilter, MenusModelFilter>();
        CreateMap<CreateMenuRequest, Menu>();
        CreateMap<UpdateMenuRequest, UpdateMenuModel>();

        // Order
        CreateMap<OrdersFilter, OrdersModelFilter>();
        CreateMap<CreateOrderRequest, Order>();
        CreateMap<UpdateOrderRequest, UpdateOrderModel>();

        // User
        CreateMap<UsersFilter, UserModelFilter>();
        CreateMap<CreateUserRequest, User>();
        CreateMap<UpdateUserRequest, UpdateUserModel>();
    }
}