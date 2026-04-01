using System.ComponentModel.DataAnnotations;

namespace MealCraft.Models;

public class UserProfile
{
    public int Id { get; set; }

    // Foreign key back to User
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int Age { get; set; }

    [MaxLength(10)]
    public string Gender { get; set; } = string.Empty;

    public double Weight { get; set; }
    public int Height { get; set; }

    [MaxLength(50)]
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

    [MaxLength(500)]
    public string? Allergies { get; set; }

    [MaxLength(500)]
    public string? HealthRestrictions { get; set; }
}