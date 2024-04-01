using System.ComponentModel.DataAnnotations;
using WebShop.Domain.Entities.User;

namespace WebShop.Domain.Entities.Order;

public class OrderEntity
{
    [Key]
    public int Id { get; set; }
        
    [Required]
    public int UserId { get; set; }
    
    [Required]
    public decimal? TotalPrice { get; set; }

    public UserEntity? User { get; set; }
}