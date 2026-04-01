using MealCraft.Models;

namespace MealCraft.Data;

public class DbSeeder
{
    public static void Seed(AppDbContext db)
    {
        if (db.Recipes.Any()) return; // already seeded

        var recipes = new List<Recipe>
        {
            new Recipe() {
                Name = "Salmon with Lemon", Category = "main",
                Calories = 560, PrepTime = 30, Difficulty = "easy",
                Protein = 40, Carbs = 8, Fat = 36,
                Image = "https://i.pinimg.com/1200x/e6/78/c7/e678c7d5f3e7682f6b4e085659bc4866.jpg",
                Ingredients = new List<RecipeIngredient> {
                    new() { Name = "salmon" },
                    new() { Name = "lemon" },
                    new() { Name = "garlic" }
                },
                Instructions = new List<RecipeInstruction> {
                    new() { StepNumber = 1, Text = "Pat the salmon dry and season with salt and pepper." },
                    new() { StepNumber = 2, Text = "Heat olive oil in a pan over medium-high heat." },
                    new() { StepNumber = 3, Text = "Sear salmon skin-side up for 4 minutes." },
                    new() { StepNumber = 4, Text = "Flip and add garlic and lemon slices." },
                    new() { StepNumber = 5, Text = "Cook for another 3 minutes, basting with pan juices." }
                },
                DietaryTags = new List<RecipeDietaryTag> {
                    new() { Tag = "Omega 3" },
                    new() { Tag = "Gluten Free" }
                }
            },
            new Recipe {
                Name = "Beef Steak", Category = "main",
                Calories = 650, PrepTime = 35, Difficulty = "medium",
                Protein = 48, Carbs = 6, Fat = 44,
                Image = "https://i.pinimg.com/736x/6d/ba/91/6dba91c1fdb5d4939c7e9d65420cbd4c.jpg",
                Ingredients = new List<RecipeIngredient> {
                    new() { Name = "beef" },
                    new() { Name = "salt" },
                    new() { Name = "pepper" }
                },
                Instructions = new List<RecipeInstruction> {
                    new() { StepNumber = 1, Text = "Take steak out of fridge 30 minutes before cooking." },
                    new() { StepNumber = 2, Text = "Season generously with salt and pepper on both sides." },
                    new() { StepNumber = 3, Text = "Heat a cast-iron skillet until smoking hot." },
                    new() { StepNumber = 4, Text = "Sear for 3-4 minutes per side for medium-rare." },
                    new() { StepNumber = 5, Text = "Rest for 5 minutes before slicing." }
                },
                DietaryTags = new List<RecipeDietaryTag> {
                    new() { Tag = "Low Carb" }
                }
            },
            new Recipe {
                Name = "Vegetable Curry", Category = "main",
                Calories = 490, PrepTime = 40, Difficulty = "medium",
                Protein = 16, Carbs = 58, Fat = 20,
                Image = "https://i.pinimg.com/1200x/66/15/4b/66154b379fa396ba3cff0eb3efec12a0.jpg",
                Ingredients = new List<RecipeIngredient> {
                    new() { Name = "vegetables" },
                    new() { Name = "coconut milk" },
                    new() { Name = "spices" }
                },
                Instructions = new List<RecipeInstruction> {
                    new() { StepNumber = 1, Text = "Dice all vegetables into even pieces." },
                    new() { StepNumber = 2, Text = "Sauté onion and garlic in oil until soft." },
                    new() { StepNumber = 3, Text = "Add curry spices and toast for 1 minute." },
                    new() { StepNumber = 4, Text = "Add vegetables and stir to coat." },
                    new() { StepNumber = 5, Text = "Pour in coconut milk and simmer for 20 minutes." }
                },
                DietaryTags = new List<RecipeDietaryTag> {
                    new() { Tag = "Vegan" }
                }
            },
            new Recipe {
                Name = "Protein Pancakes", Category = "snack",
                Calories = 410, PrepTime = 20, Difficulty = "medium",
                Protein = 32, Carbs = 40, Fat = 10,
                Image = "https://static.dir.bg/uploads/images/2023/05/31/2568131/1920x1080.jpg",
                Ingredients = new List<RecipeIngredient> {
                    new() { Name = "oats" },
                    new() { Name = "eggs" },
                    new() { Name = "banana" }
                },
                Instructions = new List<RecipeInstruction> {
                    new() { StepNumber = 1, Text = "Blend oats, eggs, and banana until smooth." },
                    new() { StepNumber = 2, Text = "Heat a non-stick pan over medium heat." },
                    new() { StepNumber = 3, Text = "Pour small rounds of batter, cook 2 minutes per side." },
                    new() { StepNumber = 4, Text = "Serve with honey or fresh fruit." }
                },
                DietaryTags = new List<RecipeDietaryTag> {
                    new() { Tag = "High Protein" }
                }
            },
            new Recipe {
                Name = "Chocolate Protein Brownies", Category = "dessert",
                Calories = 380, PrepTime = 35, Difficulty = "medium",
                Protein = 18, Carbs = 42, Fat = 16,
                Image = "https://i.pinimg.com/1200x/cd/87/b6/cd87b6aba99244e2c331ca86eadc7f9b.jpg",
                Ingredients = new List<RecipeIngredient> {
                    new() { Name = "cocoa" },
                    new() { Name = "oats" },
                    new() { Name = "eggs" }
                },
                Instructions = new List<RecipeInstruction> {
                    new() { StepNumber = 1, Text = "Preheat oven to 180°C." },
                    new() { StepNumber = 2, Text = "Blend all ingredients until smooth." },
                    new() { StepNumber = 3, Text = "Pour into a lined baking tin." },
                    new() { StepNumber = 4, Text = "Bake for 20-25 minutes." },
                    new() { StepNumber = 5, Text = "Cool completely before slicing." }
                },
                DietaryTags = new List<RecipeDietaryTag> {
                    new() { Tag = "High Protein" }
                }
            }
        };

        db.Recipes.AddRange(recipes);
        db.SaveChanges();
    }
}