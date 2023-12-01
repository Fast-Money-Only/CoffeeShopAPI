using Model;
namespace Business.Service.Interfaces;

public interface IIngredientService
{
    Ingredient CreateIngredient(Ingredient ingredient);
    Ingredient? GetIngredient(Guid id);
    void DeleteIngredient(Guid id);
    IList<Ingredient> GetIngredients();
}