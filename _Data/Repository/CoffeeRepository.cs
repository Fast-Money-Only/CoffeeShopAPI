using Model;

namespace _Data.Repository;

public class CoffeeRepository : ICoffeeRepository
{
    private readonly CoffeeShopContext _context;
    
    public CoffeeRepository(CoffeeShopContext context)
    {
        _context = context;
    }
    public IList<Coffee> GetCoffees()
    {
       return _context.Coffees.ToList();
    }

    public Coffee CreateCoffee(Coffee coffee)
    {
        _context.Coffees.Add(coffee);
        _context.SaveChanges();
        return coffee;
    }

    public void DeleteCoffee(Guid id)
    {
        _context.Coffees.Remove(GetCoffee(id));
        _context.SaveChanges();
    }

    public IList<Ingredient> CoffeeIngredients(Guid id)
    {
        IList<Ingredient> ingredients = _context.Ingredients.ToList();
        IList<CoffeeIngredient> coffeeIngredients = _context.CoffeeIngredients.ToList();

        IList<Ingredient> finalIngredients = null;

        foreach (var _coffee in coffeeIngredients)
        {
            if (_coffee.CoffeeId == id)
            {
                foreach (var _ingredient in ingredients)
                {
                    if (_coffee.IngredientId == _ingredient.Id)
                    {
                        finalIngredients.Add(_ingredient);
                    }
                }
            }
        }

        return finalIngredients;
    }

    public IList<Cake> CoffeeCake(Guid id)
    {
        throw new NotImplementedException();
    }

    public Coffee GetCoffee(Guid id)
    {
       return _context.Coffees.Find(id);
    }
}