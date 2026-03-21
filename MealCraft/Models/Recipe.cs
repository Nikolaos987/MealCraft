namespace MealCraft.Models;

public class Recipe
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public int Calories { get; set; }
    public int PrepTime { get; set; }
    public string Difficulty { get; set; } = string.Empty;
    public int Protein { get; set; }
    public int Carbs { get; set; }
    public int Fat { get; set; }
    public List<string> DietaryTags { get; set; } = new();
    public List<string> Ingredients { get; set; } = new();
    public string Image { get; set; } = string.Empty;
    public List<string> Instructions { get; set; } = new();

}