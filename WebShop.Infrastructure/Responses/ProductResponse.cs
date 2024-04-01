namespace WebShop.Infrastructure.Responses;

public class ProductResponse
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; } 
    public decimal? Price { get; init; }
}