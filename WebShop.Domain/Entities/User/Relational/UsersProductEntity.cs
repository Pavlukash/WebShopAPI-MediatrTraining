using System.ComponentModel.DataAnnotations;
using WebShop.Domain.Entities.Product;

namespace WebShop.Domain.Entities.User.Relational;

public class UsersProductEntity
{
    [Key]
    public int Id { get; set; }
        
    [Required] 
    public int UserId { get; set; }
        
    [Required] 
    public int ProductId { get; set; }
        
    public UserEntity UserEntity { get; set; }  = null!;
        
    public ProductEntity ProductEntity { get; set; }  = null!;
}