using Business.Service.Interfaces;
using Model;

namespace _Data.Repository;

public class IngredientService : IIngredientService
{
    private IIngredientRepository _ingredientRepository;

    public IngredientService(IIngredientRepository ingredientRepository)
    {
        _ingredientRepository = ingredientRepository;
    }

    public Ingredient CreateIngredient(Ingredient ingredient)
    {
        return _ingredientRepository.CreateIngredient(ingredient);
    }

    public Ingredient GetIngredient(Guid id)
    {
        return _ingredientRepository.GetIngredient(id);
    }

    public void DeleteIngredient(Guid id)
    {
        _ingredientRepository.DeleteIngredient(id);
    }

    public IList<Ingredient> GetIngredients()
    {
        return _ingredientRepository.GetIngredients();
    }
}