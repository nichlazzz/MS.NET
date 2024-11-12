using AutoMapper;
using Restoraunt.DataAccess.Migrations.Restoraunt.BL.Orders.Entities;
using Restoraunt.Restoraunt.DataAccess;

namespace Restoraunt.Restoraunt.BL.Mapper;

public class OrderBLProfile : Profile
{
    public OrderBLProfile()
    {
        // Map Order to OrderModel
        CreateMap<Order, OrderModel>()
            .ForMember(x => x.Id, y => y.MapFrom(src => src.Id)) // Assuming Id is the primary key for Order
            .ForMember(x => x._Dish, y => y.MapFrom(src => src._Dish)) 
            .ForMember(x => x._User, y => y.MapFrom(src => src._User));

        // Map CreateOrderModel to Order
        CreateMap<CreateOrderModel, Order>()
            .ForMember(x => x.Id, y => y.Ignore()); // Id is generated, so ignore it
    }
}
