using Model;
namespace _Data.Repository;

public interface ICoffeeRepository
{
    IList<Coffee> GetCoffees();
    Coffee CreateCoffee(Coffee coffee);
    void DeleteCoffee(Guid id);
    IList<Ingredient> CoffeeIngredients(Guid id);
    IList<Cake> CoffeeCake(Guid id);
    Coffee GetCoffee(Guid id);
}