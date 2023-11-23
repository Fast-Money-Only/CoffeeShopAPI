using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

public class Product
{
    [Column(TypeName = "uniqueidentifier")]
    public Guid ProductId { get; set; }
    public Guid ProductNumber { get; set; }
    [ForeignKey("ProductNumber")]
    public Object Item { get; set;}
}