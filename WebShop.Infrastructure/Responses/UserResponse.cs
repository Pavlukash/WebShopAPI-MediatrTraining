namespace WebShop.Infrastructure.Responses;

public class UserResponse
{
    public int Id { get; init; }
    public required string Name { get; init; } 
    public required string Email { get; init; } 
    public string? PhoneNumber { get; init; } 
}