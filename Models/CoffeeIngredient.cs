using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

public class CoffeeIngredient
{
    [Column(TypeName = "uniqueidentifier")]
    public Guid Id { get; set; }

    public Guid IngredientId { get; set; }
    [ForeignKey("IngredientId")]
    public Ingredient Ingredient;
    
    public Guid CoffeeId { get; set; }
    [ForeignKey("CoffeeId")]
    public Coffee Coffee;
}