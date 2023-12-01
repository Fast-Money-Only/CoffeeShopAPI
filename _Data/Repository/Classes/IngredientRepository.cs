using Model;

namespace _Data.Repository;

public class IngredientRepository : IIngredientRepository
{
    private readonly CoffeeShopContext _context;

    public IngredientRepository(CoffeeShopContext context)
    {
        _context = context;
    }

    public Ingredient CreateIngredient(Ingredient ingredient)
    {
        _context.Ingredients.Add(ingredient);
        _context.SaveChanges();
        return ingredient;
    }

    public Ingredient GetIngredient(Guid id)
    {
        return _context.Ingredients.Find(id);
    }

    public void DeleteIngredient(Guid id)
    {
        _context.Ingredients.Remove(GetIngredient(id));
        _context.SaveChanges();
    }

    public IList<Ingredient> GetIngredients()
    {
        return _context.Ingredients.ToList();
    }
}