using System.ComponentModel.DataAnnotations;
using WebShop.Domain.Entities.Product;
using WebShop.Domain.Entities.User.Relational;

namespace WebShop.Domain.Entities.Discount;

public class DiscountEntity
{
    [Key]
    public int Id { get; set; }
        
    [Required] 
    public int ProductId { get; set; }
        
    [Required]
    public decimal Discount { get; set; }
        
    public ProductEntity? Product { get; set; }

    public IEnumerable<UsersDiscountEntity>? UsersDiscountEntities { get; set; }
}