using Business.Service.Interfaces;
using Model;

namespace _Data.Repository;

public class CoffeePlaceService : ICoffeePlaceService
{
    private ICoffeePlaceRepository _coffeePlaceRepository;

    public CoffeePlaceService(ICoffeePlaceRepository coffeePlaceRepository)
    {
        _coffeePlaceRepository = coffeePlaceRepository;
    }

    public CoffeePlace GetCoffeePlace(Guid id)
    {
        return _coffeePlaceRepository.GetCoffeePlace(id);
    }
}