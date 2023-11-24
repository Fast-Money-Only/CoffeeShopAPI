using Model;
namespace Business.Service.Interfaces;

public interface ICoffeePlaceService
{
    CoffeePlace? GetCoffeePlace(Guid id);
}