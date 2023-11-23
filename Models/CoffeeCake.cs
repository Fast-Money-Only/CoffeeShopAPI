using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

public class CoffeeCake
{
    [Column(TypeName = "uniqueidentifier")]
    public Guid Id { get; set; }

    public Guid CakeId { get; set; }
    [ForeignKey("CakeId")]
    public Cake Cake;
    
    public Guid CoffeeId { get; set; }
    [ForeignKey("CoffeeId")]
    public Coffee Coffee;


}