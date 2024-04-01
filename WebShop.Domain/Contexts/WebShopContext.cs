using Microsoft.EntityFrameworkCore;
using WebShop.Domain.Entities.Discount;
using WebShop.Domain.Entities.Order;
using WebShop.Domain.Entities.Product;
using WebShop.Domain.Entities.User;
using WebShop.Domain.Entities.User.Relational;

namespace WebShop.Domain.Contexts;

public class WebShopContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; } = null!;
    public DbSet<ProductEntity> Products { get; set; } = null!;
    public DbSet<DiscountEntity> Discounts { get; set; } = null!;
    public DbSet<OrderEntity> Orders { get; set; } = null!;
    
    //Relational
    public DbSet<UsersProductEntity> UserProducts { get; set; } = null!;
    public DbSet<UsersDiscountEntity> UserDiscounts { get; set; } = null!;
    public WebShopContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //User-Order One-To-Many
        modelBuilder.Entity<OrderEntity>()
            .HasOne(x => x.User)
            .WithMany(x => x!.Orders)
            .OnDelete(DeleteBehavior.Cascade);
        
        //Product-Discount One-To-Many
        modelBuilder.Entity<DiscountEntity>()
            .HasOne(x => x.Product)
            .WithMany(x => x!.Discounts)
            .OnDelete(DeleteBehavior.Cascade);
        
        //User-Product Many-To-Many
        modelBuilder.Entity<UserEntity>()
            .HasMany(x => x.UsersProductEntities)
            .WithOne(x => x.UserEntity)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
            
        modelBuilder.Entity<ProductEntity>()
            .HasMany(x => x.UsersProductEntities)
            .WithOne(x => x.ProductEntity)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
        
        //User-Discount Many-To-Many
        modelBuilder.Entity<UserEntity>()
            .HasMany(x => x.UsersDiscountEntities)
            .WithOne(x => x.UserEntity)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<DiscountEntity>()
            .HasMany(x => x.UsersDiscountEntities)
            .WithOne(x => x.DiscountEntity)
            .HasForeignKey(x => x.DiscountId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}