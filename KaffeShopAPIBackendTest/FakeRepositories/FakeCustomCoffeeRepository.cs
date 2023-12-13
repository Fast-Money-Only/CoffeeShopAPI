using _Data;
using _Data.Repository;
using Model;

namespace KaffeShopAPIBackendTest.FakeRepositories;

public class FakeCustomCoffeeRepository : ICustomCoffeeRepository
{
    private readonly CoffeeShopContext _context;
    
    public FakeCustomCoffeeRepository(CoffeeShopContext context)
    {
        _context = context;
    }
    
    public CustomCoffee CreateCustomCoffee(CustomCoffee customCoffee)
    {
        _context.CustomCoffees.Add(customCoffee);
        _context.SaveChanges();
        return customCoffee;
    }

    public CustomCoffee? GetCustomCoffee(Guid id)
    {
        return _context.CustomCoffees.Find(id);
    }

    public CCoffeIngredient CreateCustomCoffeeIngredient(CCoffeIngredient cCoffeIngredient)
    {
        _context.CCoffeIngredients.Add(cCoffeIngredient);
        _context.SaveChanges();
        return cCoffeIngredient;
    }

    public IList<Ingredient> CustomCoffeeIngredients(Guid id)
    {
        IList<Ingredient> ingredients = _context.Ingredients.ToList();
        IList<CCoffeIngredient> customCoffeeIngredients = _context.CCoffeIngredients.ToList();

        IList<Ingredient> finalIngredients = new List<Ingredient>();

        foreach (var _coffee in customCoffeeIngredients)
        {
            if (_coffee.CustomCoffeeId == id)
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
}