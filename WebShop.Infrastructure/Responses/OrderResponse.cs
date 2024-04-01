namespace WebShop.Infrastructure.Responses;

public class OrderResponse
{
    public int Id { get; init; }
    public required int UserId { get; init; }
    public decimal? TotalPrice { get; init; }
}