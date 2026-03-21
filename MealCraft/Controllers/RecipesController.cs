using Microsoft.AspNetCore.Mvc;
using MealCraft.Models;
using MealCraft.Services;

namespace MealCraft.Controllers;

public class RecipesController : Controller
{
    private readonly RecipeService _recipeService;

    public RecipesController(RecipeService recipeService)
    {
        _recipeService = recipeService;
    }

    public IActionResult Index(
        string search = "",
        string category = "all",
        int maxCalories = 1000,
        int maxTime = 120,
        string difficulty = "all",
        string excludeIngredients = "")
    {
        ViewData["ActivePage"] = "Recipes";

        var exclude = excludeIngredients
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(s => s.Trim())
            .ToList();

        var filtered = _recipeService.Filter(
            search, category, maxCalories, maxTime, difficulty, exclude);

        var vm = new RecipeFilterViewModel
        {
            Recipes = filtered,
            Search = search,
            Category = category,
            MaxCalories = maxCalories,
            MaxTime = maxTime,
            Difficulty = difficulty,
            ExcludeIngredients = excludeIngredients,
            TotalCount = _recipeService.GetAll().Count
        };

        return View(vm);
    }

    public IActionResult Details(int id)
    {
        ViewData["ActivePage"] = "Recipes";
        var recipe = _recipeService.GetById(id);
        if (recipe == null) return NotFound();
        return View(recipe);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewData["ActivePage"] = "Recipes";
        return View();
    }
}