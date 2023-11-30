using Model;

namespace _Data.Repository;

public interface ICustomCoffeeRepository
{
    CustomCoffee CreateCustomCoffee(CustomCoffee customCoffee);
    CustomCoffee? GetCustomCoffee(Guid id);
}