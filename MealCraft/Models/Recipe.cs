using System.ComponentModel.DataAnnotations;

namespace MealCraft.Models;

public class Recipe
{
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Category { get; set; } = string.Empty;

    public int Calories { get; set; }
    public int PrepTime { get; set; }

    [MaxLength(20)]
    public string Difficulty { get; set; } = string.Empty;

    public int Protein { get; set; }
    public int Carbs { get; set; }
    public int Fat { get; set; }

    [MaxLength(500)]
    public string? Image { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Foreign key — which user created this recipe
    public int? UserId { get; set; }
    public User? User { get; set; }

    // Navigation — related rows in other tables
    public List<RecipeIngredient> Ingredients { get; set; } = new();
    public List<RecipeInstruction> Instructions { get; set; } = new();
    public List<RecipeDietaryTag> DietaryTags { get; set; } = new();
}