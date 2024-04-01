using System.ComponentModel.DataAnnotations;
using WebShop.Domain.Entities.Discount;
using WebShop.Domain.Entities.User.Relational;

namespace WebShop.Domain.Entities.Product;

public class ProductEntity
{
    [Key] 
    public int Id { get; set; }

    [Required] 
    [MaxLength(50)] 
    public string Name { get; set; } = null!;

    [Required] 
    [MaxLength(500)] 
    public string Description { get; set; } = null!;

    [Required]
    public decimal? Price { get; set; }

    public IEnumerable<UsersProductEntity>? UsersProductEntities { get; set; }
        
    public List<DiscountEntity>? Discounts { get; set; }
}