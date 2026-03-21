using System.ComponentModel.DataAnnotations;

namespace MealCraft.Models;

public class ProfileViewModel
{
    [Required(ErrorMessage = "Възрастта е задължителна")]
    [Range(10, 120, ErrorMessage = "Въведете валидна възраст")]
    public int Age { get; set; }

    [Required(ErrorMessage = "Полът е задължителен")]
    public string Gender { get; set; } = string.Empty;

    [Required(ErrorMessage = "Теглото е задължително")]
    [Range(20, 300, ErrorMessage = "Въведете валидно тегло")]
    public double Weight { get; set; }

    [Required(ErrorMessage = "Височината е задължителна")]
    [Range(50, 250, ErrorMessage = "Въведете валидна височина")]
    public int Height { get; set; }

    [Required(ErrorMessage = "Нивото на активност е задължително")]
    public string ActivityLevel { get; set; } = string.Empty;

    // Dietary preferences
    public bool NoRestrictions { get; set; }
    public bool Vegetarian { get; set; }
    public bool Vegan { get; set; }
    public bool Pescatarian { get; set; }
    public bool Keto { get; set; }
    public bool Paleo { get; set; }

    // Goals
    public bool WeightLoss { get; set; }
    public bool WeightGain { get; set; }
    public bool MaintainWeight { get; set; }
    public bool BuildMuscle { get; set; }
    public bool ImproveHealth { get; set; }

    public string? Allergies { get; set; }
    public string? HealthRestrictions { get; set; }
}