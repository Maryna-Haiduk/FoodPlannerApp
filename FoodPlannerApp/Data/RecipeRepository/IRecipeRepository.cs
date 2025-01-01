using FoodPlannerApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodPlannerApp.Data.RecipeRepository
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> GetAllRecipesAsync();
        Task<Recipe> GetRecipeByIdAsync(int id);
        Task AddRecipeAsync(Recipe recipe);
        Task UpdateRecipeAsync(Recipe recipe);
        Task DeleteRecipeAsync(int id);
    }
}
