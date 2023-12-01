using Model;

namespace _Data.Repository;

public interface ICustomCoffeeRepository
{
    CustomCoffee CreateCustomCoffee(CustomCoffee customCoffee);
    CustomCoffee? GetCustomCoffee(Guid id);
    
    CCoffeIngredient CreateCustomCoffeeIngredient(CCoffeIngredient cCoffeIngredient);
    
    IList<Ingredient> CustomCoffeeIngredients(Guid id);
}