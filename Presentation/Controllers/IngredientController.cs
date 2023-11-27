using Business.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientController : Controller
{
    private readonly IIngredientService _ingredientService;
    
    public IngredientController(IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }
    
    [HttpGet("{id}")]
    public IActionResult GetIngredient(Guid id)
    {
        var ingredient = _ingredientService.GetIngredient(id);
        return Ok(ingredient);
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteIngredient(Guid id)
    {
        try
        {
            _ingredientService.DeleteIngredient(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound();
        }
    }
    

    [HttpPost]
    public IActionResult CreateIngredient([FromBody] Ingredient ingredient)
    {
        var newIngredient = _ingredientService.CreateIngredient(ingredient);
        return CreatedAtAction(nameof(GetIngredient), new { id = newIngredient.Id }, newIngredient);
    }
}