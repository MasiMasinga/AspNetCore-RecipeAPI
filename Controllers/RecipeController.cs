using Microsoft.AspNetCore.Mvc;
using RecipeAPI.Models;
using RecipeAPI.Services;
using RecipeAPI.DTOs;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    private readonly RecipeService _service;

    public RecipesController(RecipeService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<Recipe>> CreateRecipe(CreateRecipeDto dto)
    {
        var recipe = await _service.CreateRecipeAsync(dto);
        return CreatedAtAction(nameof(GetRecipe), new { id = recipe.Id }, recipe);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<RecipeDto>>> GetRecipes()
    {
        return Ok(await _service.GetAllRecipesAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Recipe>> GetRecipe(int id)
    {
        var recipe = await _service.GetRecipeByIdAsync(id);
        if (recipe == null) return NotFound();
        return Ok(recipe);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRecipe(int id, UpdateRecipeDto dto)
    {
        var updated = await _service.UpdateRecipeAsync(id, dto);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRecipe(int id)
    {
        var deleted = await _service.DeleteRecipeAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
