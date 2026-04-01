
using MealCraft.Models;
using Microsoft.EntityFrameworkCore;

namespace MealCraft.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<UserProfile> UserProfiles => Set<UserProfile>();
    public DbSet<Recipe> Recipes => Set<Recipe>();
    public DbSet<RecipeIngredient> RecipeIngredients => Set<RecipeIngredient>();
    public DbSet<RecipeInstruction> RecipeInstructions => Set<RecipeInstruction>();
    public DbSet<RecipeDietaryTag> RecipeDietaryTags => Set<RecipeDietaryTag>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // User → unique email and username
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email).IsUnique();
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username).IsUnique();

        // User → UserProfile (one-to-one)
        modelBuilder.Entity<User>()
            .HasOne(u => u.Profile)
            .WithOne(p => p.User)
            .HasForeignKey<UserProfile>(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // User → Recipes (one-to-many)
        modelBuilder.Entity<Recipe>()
            .HasOne(r => r.User)
            .WithMany(u => u.Recipes)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.SetNull);

        // Recipe → Ingredients
        modelBuilder.Entity<RecipeIngredient>()
            .HasOne(i => i.Recipe)
            .WithMany(r => r.Ingredients)
            .HasForeignKey(i => i.RecipeId)
            .OnDelete(DeleteBehavior.Cascade);

        // Recipe → Instructions
        modelBuilder.Entity<RecipeInstruction>()
            .HasOne(i => i.Recipe)
            .WithMany(r => r.Instructions)
            .HasForeignKey(i => i.RecipeId)
            .OnDelete(DeleteBehavior.Cascade);

        // Recipe → DietaryTags
        modelBuilder.Entity<RecipeDietaryTag>()
            .HasOne(t => t.Recipe)
            .WithMany(r => r.DietaryTags)
            .HasForeignKey(t => t.RecipeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
