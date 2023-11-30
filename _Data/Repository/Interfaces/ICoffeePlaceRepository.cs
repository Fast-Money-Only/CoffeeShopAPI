using Model;
namespace _Data.Repository;

public interface ICoffeePlaceRepository
{
    CoffeePlace GetCoffeePlace(Guid id);
    IList<CoffeePlace> GetCoffeePlaceces();
}