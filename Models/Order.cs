using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

public class Order
{
    [Column(TypeName = "uniqueidentifier")]
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Pickup { get; set; }
    
    public Guid CoffeePlaceId { get; set; }
    [ForeignKey("CoffeePlaceId")]
    public CoffeePlace CoffeePlace { get; set; }
    
    public Guid UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }
}