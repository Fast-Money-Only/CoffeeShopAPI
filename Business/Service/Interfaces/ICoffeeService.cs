using Model;
namespace Business.Service.Interfaces;

public interface ICoffeeService
{
    IList<Coffee> GetCoffees();
    Coffee CreateCoffee(Coffee coffee);
    void DeleteCoffee(Guid id);
    IList<Ingredient> CoffeeIngredients(Guid id);
    IList<Cake> CoffeeCake(Guid id);
    Coffee? GetCoffee(Guid id);
    CoffeeIngredient CreateCoffeeIngredient(CoffeeIngredient coffeeIngredient);
}