using Model;
namespace Business.Service.Interfaces;

public interface ICustomCoffeeService
{
    CustomCoffee CreateCustomCoffee(CustomCoffee customCoffee);
    CustomCoffee? GetCustomCoffee(Guid id);
}