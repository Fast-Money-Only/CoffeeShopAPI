using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

public class OrderProduct
{
    [Column(TypeName = "uniqueidentifier")]
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }
    [ForeignKey("ProductId")]
    public Product Product;
    
    public Guid OrderId { get; set; }
    [ForeignKey("OrderId")]
    public Order Order;

    public int Quantity { get; set; }
    
}