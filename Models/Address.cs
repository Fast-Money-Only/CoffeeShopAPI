using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

public class Address
{
    [Column(TypeName = "uniqueidentifier")]
    public Guid AddressID {get; set;}
    public string StreetName {get; set;}
    public string HouseNumber { get; set;}
    public string CityName { get; set;}
    public int PostNumber { get; set;}
}