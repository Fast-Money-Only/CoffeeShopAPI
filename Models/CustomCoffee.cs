using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

public class CustomCoffee
{
    [Column(TypeName = "uniqueidentifier")]
    public Guid CustomCoffeeId { get; set; }
    public string Name { get; set; }
}