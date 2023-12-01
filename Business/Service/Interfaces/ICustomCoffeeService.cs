using Model;
namespace Business.Service.Interfaces;

public interface ICustomCoffeeService
{
    CustomCoffee CreateCustomCoffee(CustomCoffee customCoffee);
    CustomCoffee? GetCustomCoffee(Guid id);
    
    CCoffeIngredient CreateCustomCoffeeIngredient(CCoffeIngredient cCoffeIngredient);
    
    IList<Ingredient> CustomCoffeeIngredients(Guid id);
}