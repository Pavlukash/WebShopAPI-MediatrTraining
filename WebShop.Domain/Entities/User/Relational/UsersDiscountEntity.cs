using System.ComponentModel.DataAnnotations;
using WebShop.Domain.Entities.Discount;

namespace WebShop.Domain.Entities.User.Relational;

public class UsersDiscountEntity
{
    [Key]
    public int Id { get; set; }
        
    [Required] 
    public int UserId { get; set; }
        
    [Required] 
    public int DiscountId { get; set; }
        
    public UserEntity UserEntity { get; set; }  = null!;
        
    public DiscountEntity DiscountEntity { get; set; }  = null!;
}