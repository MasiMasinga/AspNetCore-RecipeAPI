using Microsoft.EntityFrameworkCore;
using RecipeAPI.Models;
using RecipeAPI.Data;
using RecipeAPI.DTOs;

namespace RecipeAPI.Services
{
    public class RecipeService
    {
        private readonly AppDbContext _context;

        public RecipeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Recipe> CreateRecipeAsync(CreateRecipeDto dto)
        {
            var recipe = new Recipe
            {
                Name = dto.Name,
                Description = dto.Description,
                Instructions = dto.Instructions,
                Duration = dto.Duration
            };

            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
            return recipe;
        }

        public async Task<Recipe?> GetRecipeByIdAsync(int id)
        {
            return await _context.Recipes.FindAsync(id);
        }

        public async Task<List<RecipeDto>> GetAllRecipesAsync()
        {
            return await _context.Recipes
                .Select(r => new RecipeDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    Instructions = r.Instructions,
                    Duration = r.Duration
                })
                .ToListAsync();
        }

        public async Task<bool> UpdateRecipeAsync(int id, UpdateRecipeDto dto)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null) return false;

            recipe.Name = dto.Name;
            recipe.Description = dto.Description;
            recipe.Instructions = dto.Instructions;
            recipe.Duration = dto.Duration;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRecipeAsync(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null) return false;

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}