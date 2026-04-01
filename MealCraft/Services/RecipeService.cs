using Microsoft.EntityFrameworkCore;
using MealCraft.Data;
using MealCraft.Models;

namespace MealCraft.Services;

public class RecipeService
{
    private readonly AppDbContext _db;

    public RecipeService(AppDbContext db)
    {
        _db = db;
    }

    public List<Recipe> GetAll()
    {
        return _db.Recipes
            .Include(r => r.Ingredients)
            .Include(r => r.Instructions)
            .Include(r => r.DietaryTags)
            .ToList();
    }

    public Recipe? GetById(int id)
    {
        return _db.Recipes
            .Include(r => r.Ingredients)
            .Include(r => r.Instructions.OrderBy(i => i.StepNumber))
            .Include(r => r.DietaryTags)
            .FirstOrDefault(r => r.Id == id);
    }

    public List<Recipe> Filter(
        string search, string category, int maxCalories,
        int maxTime, string difficulty, List<string> includeIngredients)
    {
        var query = _db.Recipes
            .Include(r => r.Ingredients)
            .Include(r => r.DietaryTags)
            .AsQueryable();

        if (!string.IsNullOrEmpty(search))
            query = query.Where(r =>
                r.Name.Contains(search) ||
                r.Ingredients.Any(i => i.Name.Contains(search)));

        if (category != "all")
            query = query.Where(r => r.Category == category);

        query = query.Where(r => r.Calories <= maxCalories);
        query = query.Where(r => r.PrepTime <= maxTime);

        if (difficulty != "all")
            query = query.Where(r => r.Difficulty == difficulty);

        if (includeIngredients.Count > 0)
            query = query.Where(r =>
                includeIngredients.Any(e =>
                    r.Ingredients.Any(i => i.Name == e)));

        return query.ToList();
    }

    public void Add(Recipe recipe)
    {
        _db.Recipes.Add(recipe);
        _db.SaveChanges();
    }

    public void Delete(int id)
    {
        var recipe = _db.Recipes.Find(id);
        if (recipe != null)
        {
            _db.Recipes.Remove(recipe);
            _db.SaveChanges();
        }
    }
}