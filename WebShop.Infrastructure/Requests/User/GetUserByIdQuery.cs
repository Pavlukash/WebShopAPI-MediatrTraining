using MediatR;
using WebShop.Infrastructure.Responses;

namespace WebShop.Infrastructure.Requests.User;

public record GetUserByIdQuery(int Id) : IRequest<UserResponse>;