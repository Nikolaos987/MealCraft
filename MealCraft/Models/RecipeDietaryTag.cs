using System.ComponentModel.DataAnnotations;

namespace MealCraft.Models;

public class RecipeDietaryTag
{
    public int Id { get; set; }

    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string Tag { get; set; } = string.Empty;
}