using MediatR;
using WebShop.Infrastructure.Responses;

namespace WebShop.Infrastructure.Requests.User;

public record CreateUserCommand : IRequest<UserResponse>
{
    public required string Name { get; init; } 
    public required string Email { get; init; } 
    public string? PhoneNumber { get; init; } 
};