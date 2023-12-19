using _Data.Repository;
using Business.Service.Interfaces;
using Model;

namespace ClassLibrary1.Service.Classes;

public class CustomCoffeeService : ICustomCoffeeService
{
    
    private ICustomCoffeeRepository _customCoffeeRepository;

    public CustomCoffeeService(ICustomCoffeeRepository customCoffeeRepository)
    {
        _customCoffeeRepository = customCoffeeRepository;
    }
    
    
    public CustomCoffee CreateCustomCoffee(CustomCoffee customCoffee)
    {
        return _customCoffeeRepository.CreateCustomCoffee(customCoffee);
    }

    public CustomCoffee? GetCustomCoffee(Guid id)
    {
        return _customCoffeeRepository.GetCustomCoffee(id);
    }

    public CCoffeIngredient CreateCustomCoffeeIngredient(CCoffeIngredient cCoffeIngredient)
    {
        return _customCoffeeRepository.CreateCustomCoffeeIngredient(cCoffeIngredient);
    }

    public IList<Ingredient> CustomCoffeeIngredients(Guid id)
    {
        return _customCoffeeRepository.CustomCoffeeIngredients(id);
    }
}