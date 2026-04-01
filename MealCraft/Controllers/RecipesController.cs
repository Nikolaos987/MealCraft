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

    // [HttpGet]
    // public IActionResult Create()
    // {
    //     ViewData["ActivePage"] = "Recipes";
    //     return View();
    // }
    
    [HttpGet]
    public IActionResult Create()
    {
        ViewData["ActivePage"] = "Recipes";
        return View(new CreateRecipeViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CreateRecipeViewModel model)
    {
        ViewData["ActivePage"] = "Recipes";
        if (!ModelState.IsValid) return View(model);

        var recipe = new Recipe
        {
            Name = model.Name,
            Category = model.Category,
            PrepTime = model.PrepTime,
            Calories = model.Calories,
            Difficulty = model.Difficulty,
            Protein = model.Protein,
            Carbs = model.Carbs,
            Fat = model.Fat,
            Image = model.ImageUrl ?? "https://placehold.co/800x450?text=No+Image",
            Ingredients = model.Ingredients
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select((name, _) => new RecipeIngredient
                {
                    Name = name.Trim()
                }).ToList(),
            Instructions = model.Instructions
                .Split('\n', StringSplitOptions.RemoveEmptyEntries)
                .Select((text, index) => new RecipeInstruction
                {
                    StepNumber = index + 1,
                    Text = text.Trim()
                }).ToList(),
            DietaryTags = string.IsNullOrWhiteSpace(model.DietaryTags)
                ? new List<RecipeDietaryTag>()
                : model.DietaryTags
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(t => new RecipeDietaryTag
                    {
                        Tag = t.Trim()
                    }).ToList()
        };

        _recipeService.Add(recipe);
        return RedirectToAction(nameof(Index));
    }
}