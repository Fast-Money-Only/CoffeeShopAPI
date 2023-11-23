using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

public class CCoffeIngredient
{
    [Column(TypeName = "uniqueidentifier")]
    public Guid Id { get; set; }

    public Guid CakeId { get; set; }
    [ForeignKey("CakeId")]
    public Cake Cake;
    
    public Guid CustomCoffeeId { get; set; }
    [ForeignKey("CustomCoffeeId")]
    public CustomCoffee CustomCoffee;
}