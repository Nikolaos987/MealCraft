using System.ComponentModel.DataAnnotations;

namespace MealCraft.Models;

public class CreateRecipeViewModel
{
    [Required(ErrorMessage = "Името е задължително")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Името трябва да е между 3 и 100 символа")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Категорията е задължителна")]
    public string Category { get; set; } = string.Empty;

    [Required(ErrorMessage = "Времето за приготвяне е задължително")]
    [Range(1, 300, ErrorMessage = "Времето трябва да е между 1 и 300 минути")]
    public int PrepTime { get; set; }

    [Required(ErrorMessage = "Калориите са задължителни")]
    [Range(1, 5000, ErrorMessage = "Калориите трябва да са между 1 и 5000")]
    public int Calories { get; set; }

    [Required(ErrorMessage = "Трудността е задължителна")]
    public string Difficulty { get; set; } = string.Empty;

    [Range(0, 500, ErrorMessage = "Невалидна стойност")]
    public int Protein { get; set; }

    [Range(0, 500, ErrorMessage = "Невалидна стойност")]
    public int Carbs { get; set; }

    [Range(0, 500, ErrorMessage = "Невалидна стойност")]
    public int Fat { get; set; }

    [Required(ErrorMessage = "Съставките са задължителни")]
    public string Ingredients { get; set; } = string.Empty; // comma-separated

    [Required(ErrorMessage = "Инструкциите са задължителни")]
    public string Instructions { get; set; } = string.Empty; // one per line

    public string? ImageUrl { get; set; }

    public string? DietaryTags { get; set; } // comma-separated
}