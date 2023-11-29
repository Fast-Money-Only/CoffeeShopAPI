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

        IList<Ingredient> finalIngredients = new List<Ingredient>();

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
        IList<Cake> cakes = _context.Cakes.ToList();
        IList<CoffeeCake> coffeeCakes = _context.CoffeeCakes.ToList();

        IList<Cake> finalCakes = new List<Cake>();
        
        foreach (var _coffeeCake in coffeeCakes)
        {
            if (_coffeeCake.CoffeeId == id)
            {
                foreach (var _cake in cakes)
                {
                    if (_coffeeCake.CakeId == _cake.Id)
                    {
                        finalCakes.Add(_cake);
                    }
                }
            }
        }

        return finalCakes;
    }

    public Coffee GetCoffee(Guid id)
    {
       return _context.Coffees.Find(id);
    }

    public CoffeeIngredient CreateCoffeeIngredient(CoffeeIngredient coffeeIngredient)
    {

        _context.CoffeeIngredients.Add(coffeeIngredient);
        _context.SaveChanges();

        return coffeeIngredient;

    }

    public CoffeeCake CreateCoffeeCake(CoffeeCake coffeeCake)
    {
        _context.CoffeeCakes.Add(coffeeCake);
        _context.SaveChanges();

        return coffeeCake;
    }
}