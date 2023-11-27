using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

public class Product
{
    [Column(TypeName = "uniqueidentifier")]
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public Guid ProductNumber { get; set; }
    
}