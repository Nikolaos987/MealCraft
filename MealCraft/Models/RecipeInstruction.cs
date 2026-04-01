using System.ComponentModel.DataAnnotations;

namespace MealCraft.Models;

public class RecipeInstruction
{
    public int Id { get; set; }

    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; } = null!;

    public int StepNumber { get; set; }

    [Required]
    [MaxLength(1000)]
    public string Text { get; set; } = string.Empty;
}