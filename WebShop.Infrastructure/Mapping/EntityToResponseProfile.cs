using AutoMapper;
using WebShop.DataAccess.Contracts;
using WebShop.Domain.Entities.Discount;
using WebShop.Domain.Entities.Order;
using WebShop.Domain.Entities.Product;
using WebShop.Domain.Entities.User;
using WebShop.Infrastructure.Responses;

namespace WebShop.Infrastructure.Mapping;

public class EntityToResponseProfile : Profile
{
    public EntityToResponseProfile()
    {
        CreateMap<UserEntity, UserResponse>();
        CreateMap<PagedList<UserEntity>, PagedList<UserResponse>>()
            .ForMember(d => d.Items, 
                opt
                    => opt.MapFrom(s => s.Items));
        
        CreateMap<ProductEntity, ProductResponse>();
        CreateMap<PagedList<ProductEntity>, PagedList<ProductResponse>>()
            .ForMember(d => d.Items, 
                opt
                    => opt.MapFrom(s => s.Items));
        
        CreateMap<OrderEntity, OrderResponse>();
        CreateMap<PagedList<OrderEntity>, PagedList<OrderResponse>>()
            .ForMember(d => d.Items, 
                opt
                    => opt.MapFrom(s => s.Items));
        
        CreateMap<DiscountEntity, DiscountResponse>();
        CreateMap<PagedList<DiscountEntity>, PagedList<DiscountResponse>>()
            .ForMember(d => d.Items, 
                opt
                    => opt.MapFrom(s => s.Items));
    }
}