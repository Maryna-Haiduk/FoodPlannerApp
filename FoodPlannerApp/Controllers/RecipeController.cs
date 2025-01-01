using Microsoft.AspNetCore.Mvc;
using FoodPlannerApp.Models;
using FoodPlannerApp.Data.RecipeRepository;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodPlannerApp.Controllers
{
    [Authorize]
    public class RecipeController : Controller
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeController(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        // GET: Recipe
        public async Task<IActionResult> Index()
        {
            var recipes = await _recipeRepository.GetAllRecipesAsync();
            return View(recipes);
        }

        // GET: Recipe/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var recipe = await _recipeRepository.GetRecipeByIdAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        // GET: Recipe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recipe/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                await _recipeRepository.AddRecipeAsync(recipe);
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: Recipe/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var recipe = await _recipeRepository.GetRecipeByIdAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        // POST: Recipe/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _recipeRepository.UpdateRecipeAsync(recipe);
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: Recipe/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var recipe = await _recipeRepository.GetRecipeByIdAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        // POST: Recipe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _recipeRepository.DeleteRecipeAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
