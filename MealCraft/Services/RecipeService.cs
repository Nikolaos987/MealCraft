using MealCraft.Models;

namespace MealCraft.Services;

public class RecipeService
{
    private static readonly List<Recipe> _recipes = new()
    {
        new Recipe {
            Id = 1, Name = "Salmon with Lemon", Category = "main",
            Calories = 560, PrepTime = 30, Difficulty = "easy",
            Protein = 40, Carbs = 8, Fat = 36,
            DietaryTags = new() { "Omega 3", "Gluten Free" },
            Ingredients = new() { "salmon", "lemon", "garlic" },
            Image = "https://i.pinimg.com/1200x/e6/78/c7/e678c7d5f3e7682f6b4e085659bc4866.jpg",
            Instructions = new() {
                "Pat the salmon dry and season with salt and pepper.",
                "Heat olive oil in a pan over medium-high heat.",
                "Sear the salmon skin-side up for 4 minutes.",
                "Flip and add garlic and lemon slices to the pan.",
                "Cook for another 3 minutes, basting with the pan juices.",
                "Serve immediately with lemon wedges."
            }
        },
        new Recipe {
            Id = 2, Name = "Beef Steak", Category = "main",
            Calories = 650, PrepTime = 35, Difficulty = "medium",
            Protein = 48, Carbs = 6, Fat = 44,
            DietaryTags = new() { "Low Carb" },
            Ingredients = new() { "beef", "salt", "pepper" },
            Image = "https://i.pinimg.com/736x/6d/ba/91/6dba91c1fdb5d4939c7e9d65420cbd4c.jpg",
            Instructions = new() {
                "Take the steak out of the fridge 30 minutes before cooking.",
                "Season generously with salt and pepper on both sides.",
                "Heat a cast-iron skillet until smoking hot.",
                "Sear the steak for 3–4 minutes per side for medium-rare.",
                "Rest for 5 minutes before slicing."
            }
        },
        new Recipe {
            Id = 3, Name = "Vegetable Curry", Category = "main",
            Calories = 490, PrepTime = 40, Difficulty = "medium",
            Protein = 16, Carbs = 58, Fat = 20,
            DietaryTags = new() { "Vegan" },
            Ingredients = new() { "vegetables", "coconut milk", "spices" },
            Image = "https://i.pinimg.com/1200x/66/15/4b/66154b379fa396ba3cff0eb3efec12a0.jpg",
            Instructions = new() {
                "Dice all vegetables into even pieces.",
                "Sauté onion and garlic in oil until soft.",
                "Add curry spices and toast for 1 minute.",
                "Add vegetables and stir to coat.",
                "Pour in coconut milk and simmer for 20 minutes.",
                "Serve over rice."
            }
        },
        new Recipe {
            Id = 4, Name = "Grilled Chicken", Category = "main",
            Calories = 420, PrepTime = 20, Difficulty = "easy",
            Protein = 38, Carbs = 0, Fat = 28,
            DietaryTags = new() { "Gluten Free" },
            Ingredients = new() { "chicken breast", "salt", "olive oil" },
            Image = "https://i.pinimg.com/1200x/74/7c/0e/747c0eee42e6f5a080ac7b2f1ffae5b4.jpg",
            Instructions = new() {
                "Pound chicken breasts to even thickness.",
                "Brush with olive oil and season with salt.",
                "Grill on medium-high heat for 6 minutes per side.",
                "Rest for 3 minutes before serving."
            }
        },
        new Recipe {
            Id = 5, Name = "Pasta Bolognese", Category = "main",
            Calories = 680, PrepTime = 45, Difficulty = "medium",
            Protein = 32, Carbs = 72, Fat = 22,
            DietaryTags = new() { "Comfort Food" },
            Ingredients = new() { "pasta", "beef", "tomato" },
            Image = "https://i.pinimg.com/1200x/f7/04/71/f704713cebf2e0e9837fd0afebf6745e.jpg",
            Instructions = new() {
                "Brown the minced beef in a large pan.",
                "Add onion and garlic, cook until soft.",
                "Stir in tomato paste and crushed tomatoes.",
                "Simmer for 25 minutes.",
                "Cook pasta until al dente, drain and combine.",
                "Serve with grated parmesan."
            }
        },
        new Recipe {
            Id = 6, Name = "Quinoa Power Bowl", Category = "main",
            Calories = 480, PrepTime = 25, Difficulty = "easy",
            Protein = 20, Carbs = 60, Fat = 14,
            DietaryTags = new() { "Vegan", "Gluten Free" },
            Ingredients = new() { "quinoa", "chickpeas", "vegetables" },
            Image = "https://i.pinimg.com/736x/62/8d/c7/628dc7e242689a236d9e05af9e4c7cdf.jpg",
            Instructions = new() {
                "Rinse quinoa and cook in vegetable broth for 15 minutes.",
                "Roast chickpeas with spices at 200°C for 20 minutes.",
                "Chop fresh vegetables of your choice.",
                "Assemble the bowl and drizzle with tahini dressing."
            }
        },
        new Recipe {
            Id = 7, Name = "Baked Chicken Thighs", Category = "main",
            Calories = 610, PrepTime = 40, Difficulty = "easy",
            Protein = 44, Carbs = 8, Fat = 38,
            DietaryTags = new() { "Low Carb" },
            Ingredients = new() { "chicken", "paprika", "garlic" },
            Image = "https://i.pinimg.com/1200x/b5/f3/83/b5f383600978f657592ba9ccbabbe1be.jpg",
            Instructions = new() {
                "Preheat oven to 200°C.",
                "Mix paprika, garlic powder, salt and olive oil.",
                "Coat chicken thighs in the spice mix.",
                "Bake for 35–40 minutes until golden.",
                "Rest for 5 minutes before serving."
            }
        },
        new Recipe {
            Id = 8, Name = "Protein Pancakes", Category = "snack",
            Calories = 410, PrepTime = 20, Difficulty = "medium",
            Protein = 32, Carbs = 40, Fat = 10,
            DietaryTags = new() { "High Protein" },
            Ingredients = new() { "oats", "eggs", "banana" },
            Image = "https://static.dir.bg/uploads/images/2023/05/31/2568131/1920x1080.jpg",
            Instructions = new() {
                "Blend oats, eggs, and banana until smooth.",
                "Heat a non-stick pan over medium heat.",
                "Pour small rounds of batter and cook 2 minutes per side.",
                "Serve with honey or fresh fruit."
            }
        },
        new Recipe {
            Id = 9, Name = "Avocado Toast", Category = "snack",
            Calories = 320, PrepTime = 10, Difficulty = "easy",
            Protein = 8, Carbs = 34, Fat = 18,
            DietaryTags = new() { "Vegetarian" },
            Ingredients = new() { "avocado", "bread" },
            Image = "https://i.pinimg.com/1200x/c9/a7/18/c9a7181b6e8112b3db683b1d1cbf9c59.jpg",
            Instructions = new() {
                "Toast the bread to your liking.",
                "Mash avocado with salt, pepper and lemon juice.",
                "Spread on toast and add toppings of your choice."
            }
        },
        new Recipe {
            Id = 10, Name = "Chocolate Protein Brownies", Category = "dessert",
            Calories = 380, PrepTime = 35, Difficulty = "medium",
            Protein = 18, Carbs = 42, Fat = 16,
            DietaryTags = new() { "High Protein" },
            Ingredients = new() { "cocoa", "oats", "eggs" },
            Image = "https://i.pinimg.com/1200x/cd/87/b6/cd87b6aba99244e2c331ca86eadc7f9b.jpg",
            Instructions = new() {
                "Preheat oven to 180°C.",
                "Blend all ingredients until smooth.",
                "Pour into a lined baking tin.",
                "Bake for 20–25 minutes.",
                "Cool completely before slicing."
            }
        },
        new Recipe {
            Id = 11, Name = "Greek Yogurt Cheesecake", Category = "dessert",
            Calories = 420, PrepTime = 50, Difficulty = "hard",
            Protein = 22, Carbs = 36, Fat = 22,
            DietaryTags = new() { "Protein Dessert" },
            Ingredients = new() { "yogurt", "cream cheese", "eggs" },
            Image = "https://i.pinimg.com/1200x/ad/aa/4b/adaa4b44f18b22c84de25246f79bc0a6.jpg",
            Instructions = new() {
                "Mix yogurt, cream cheese and sugar until smooth.",
                "Beat in eggs one at a time.",
                "Pour over a prepared biscuit base.",
                "Bake at 160°C for 45 minutes.",
                "Refrigerate overnight before serving."
            }
        },
    };

    public List<Recipe> GetAll() => _recipes;

    public Recipe? GetById(int id) => _recipes.FirstOrDefault(r => r.Id == id);

    public List<Recipe> Filter(
        string search, string category, int maxCalories,
        int maxTime, string difficulty, List<string> excludeIngredients)
    {
        return _recipes.Where(r =>
        {
            bool matchesSearch = string.IsNullOrEmpty(search) ||
                r.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                r.Ingredients.Any(i => i.Contains(search, StringComparison.OrdinalIgnoreCase));

            bool matchesCategory = category == "all" ||
                r.Category.Equals(category, StringComparison.OrdinalIgnoreCase);

            bool matchesCalories = r.Calories <= maxCalories;
            bool matchesTime = r.PrepTime <= maxTime;

            bool matchesDifficulty = difficulty == "all" ||
                r.Difficulty.Equals(difficulty, StringComparison.OrdinalIgnoreCase);

            bool matchesIngredients = excludeIngredients.Count == 0 ||
                excludeIngredients.Any(e =>
                    r.Ingredients.Any(i => i.Equals(e, StringComparison.OrdinalIgnoreCase)));

            return matchesSearch && matchesCategory && matchesCalories
                && matchesTime && matchesDifficulty && matchesIngredients;
        }).ToList();
    }
}