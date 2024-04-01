using System.ComponentModel.DataAnnotations;
using WebShop.Domain.Entities.Order;
using WebShop.Domain.Entities.User.Relational;

namespace WebShop.Domain.Entities.User;

public class UserEntity
{
    [Key]
    public int Id { get; set; }

    [Required] 
    [MaxLength(20)] 
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string Email { get; set; } = null!;
        
    [MaxLength(20)]
    public string? PhoneNumber { get; set; } 
    
    public IEnumerable<OrderEntity>? Orders { get; set; }
    
    public IEnumerable<UsersProductEntity>? UsersProductEntities { get; set; }
        
    public IEnumerable<UsersDiscountEntity>? UsersDiscountEntities { get; set; }
}