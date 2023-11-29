using Business.Service.Interfaces;
using Model;

namespace _Data.Repository;

public class CoffeeService : ICoffeeService
{
    private ICoffeeRepository _coffeeRepository;

    public CoffeeService(ICoffeeRepository coffeeRepository)
    {
        _coffeeRepository = coffeeRepository;
    }

    public IList<Coffee> GetCoffees()
    {
        return _coffeeRepository.GetCoffees();
    }

    public Coffee CreateCoffee(Coffee coffee)
    {
        return _coffeeRepository.CreateCoffee(coffee);
    }

    public void DeleteCoffee(Guid id)
    {
        _coffeeRepository.DeleteCoffee(id);
    }

    public IList<Ingredient> CoffeeIngredients(Guid id)
    {
        return _coffeeRepository.CoffeeIngredients(id);
    }

    public IList<Cake> CoffeeCake(Guid id)
    {
        return _coffeeRepository.CoffeeCake(id);
    }

    public Coffee GetCoffee(Guid id)
    {
        return _coffeeRepository.GetCoffee(id);
    }

    public CoffeeIngredient CreateCoffeeIngredient(CoffeeIngredient coffeeIngredient)
    {
        return _coffeeRepository.CreateCoffeeIngredient(coffeeIngredient);
    }
}