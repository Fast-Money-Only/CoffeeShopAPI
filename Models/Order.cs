using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

public class Order
{
    [Column(TypeName = "uniqueidentifier")]
    public Guid Id { get; set; }
    public string Created { get; set; }
    public string Pickup { get; set; }
    public bool IsDone { get; set; }

    public Guid CoffeePlaceId { get; set; }
    [ForeignKey("CoffeePlaceId")]
    public CoffeePlace CoffeePlace { get; set; }
    
    public Guid UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }
}