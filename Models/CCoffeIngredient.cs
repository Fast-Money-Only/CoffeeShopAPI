using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

public class CCoffeIngredient
{
    [Column(TypeName = "uniqueidentifier")]
    public Guid Id { get; set; }

    public Guid IngredientId { get; set; }
    [ForeignKey("IngredientId")]
    public Ingredient Ingredient;
    
    public Guid CustomCoffeeId { get; set; }
    [ForeignKey("CustomCoffeeId")]
    public CustomCoffee CustomCoffee;
}