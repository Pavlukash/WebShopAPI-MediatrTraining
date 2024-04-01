using AutoMapper;
using WebShop.Domain.Entities.Discount;
using WebShop.Domain.Entities.Order;
using WebShop.Domain.Entities.Product;
using WebShop.Domain.Entities.User;
using WebShop.Infrastructure.Requests.User;
using WebShop.Infrastructure.Responses;

namespace WebShop.Infrastructure.Mapping;

public class RequestToEntityProfile : Profile
{
    public RequestToEntityProfile()
    {
        CreateMap<CreateUserCommand, UserEntity>();
    }
}