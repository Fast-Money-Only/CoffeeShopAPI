namespace Model;

public class GetOrderProductDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    // indsæt pris her efter db update (public double Price { get; set;})
    

}