using MediatR;
using WebShop.Infrastructure.Responses;

namespace WebShop.Infrastructure.Requests.User;

public record DeleteUserCommand(int Id) : IRequest<bool>;