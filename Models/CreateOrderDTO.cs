namespace Model;

public class CreateOrderDTO
{
    public Guid Id { get; set; }
    public string Created { get; set; }
    public string Pickup { get; set; }
    public bool IsDone { get; set; }
    public Guid CoffeePlaceId { get; set; }
    public Guid UserId { get; set; }
}