using Model;

namespace _Data.Repository;

public class CoffeeRepository : ICoffeeRepository
{
    public IList<Coffee> GetCoffees()
    {
        throw new NotImplementedException();
    }

    public Coffee CreateCoffee(Coffee coffee)
    {
        throw new NotImplementedException();
    }

    public void DeleteCoffee(Guid id)
    {
        throw new NotImplementedException();
    }

    public IList<Ingredient> CoffeeIngredients(Guid id)
    {
        throw new NotImplementedException();
    }

    public IList<Cake> CoffeeCake(Guid id)
    {
        throw new NotImplementedException();
    }
}