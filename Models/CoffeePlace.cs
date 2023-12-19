using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

public class CoffeePlace
{
    [Column(TypeName = "uniqueidentifier")]
    public Guid CoffeePlaceId { get; set; }
    public string CoffeePlaceName { get; set; }
    public Guid AddressId { get; set; }
    [ForeignKey("AddressId")]
    public Address Address { get; set; }
}