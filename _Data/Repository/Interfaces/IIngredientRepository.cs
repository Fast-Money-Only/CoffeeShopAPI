using Model;
namespace _Data.Repository;

public interface IIngredientRepository
{
    Ingredient CreateIngredient(Ingredient ingredient);
    Ingredient GetIngredient(Guid id);
    void DeleteIngredient(Guid id);
    IList<Ingredient> GetIngredients();
}