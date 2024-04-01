namespace WebShop.Infrastructure.Responses;

public class DiscountResponse
{
    public int Id { get; init; }
    public required int ProductId { get; init; }
    public required decimal Discount { get; init; }
}