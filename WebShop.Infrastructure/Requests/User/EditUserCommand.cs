using MediatR;
using WebShop.Infrastructure.Responses;

namespace WebShop.Infrastructure.Requests.User;

public record EditUserCommand : IRequest<UserResponse>
{
    public int Id { get; init; }
    public string? Name { get; init; } 
    public string? Email { get; init; } 
    public string? PhoneNumber { get; init; } 
};