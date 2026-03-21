namespace MealCraft.Models;

public class RecipeFilterViewModel
{
    public List<Recipe> Recipes { get; set; } = new();
    public string Search { get; set; } = string.Empty;
    public string Category { get; set; } = "all";
    public int MaxCalories { get; set; } = 1000;
    public int MaxTime { get; set; } = 120;
    public string Difficulty { get; set; } = "all";
    public string ExcludeIngredients { get; set; } = string.Empty;
    public int TotalCount { get; set; }

}