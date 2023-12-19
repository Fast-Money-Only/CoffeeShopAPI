using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

public class Cake
{
    [Column(TypeName = "uniqueidentifier")]
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public double Price { get; set; }
}