using Microsoft.EntityFrameworkCore;
using Model;

namespace _Data;

public class CoffeeShopContext : DbContext
{
    public CoffeeShopContext(DbContextOptions<CoffeeShopContext> options) : base(options)
    {
        
    }
    
    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<Cake> Cakes { get; set; } = null!;
    public DbSet<CCoffeIngredient> CCoffeIngredients { get; set; } = null!;
    public DbSet<Coffee> Coffees { get; set; } = null!;
    public DbSet<CoffeeCake> CoffeeCakes { get; set; } = null!;
    public DbSet<CoffeeIngredient> CoffeeIngredients { get; set; } = null!;
    public DbSet<CoffeePlace> CoffeePlaces { get; set; } = null!;
    public DbSet<CustomCoffee> CustomCoffees { get; set; } = null!;
    public DbSet<Ingredient> Ingredients { get; set; } = null!;
    public DbSet<Membership> Memberships { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderProduct> OrderProducts { get; set; } = null!;
    public DbSet<Post> Posts { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    
}