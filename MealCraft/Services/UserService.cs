using MealCraft.Data;
using MealCraft.Models;
using Microsoft.EntityFrameworkCore;

namespace MealCraft.Services;

public class UserService
{
    private readonly AppDbContext _db;

    public UserService(AppDbContext db)
    {
        _db = db;
    }

    public User? GetById(int id)
    {
        return _db.Users
            .Include(u => u.Profile)
            .FirstOrDefault(u => u.Id == id);
    }

    public User? GetByUsername(string username)
    {
        return _db.Users
            .Include(u => u.Profile)
            .FirstOrDefault(u => u.Username == username);
    }

    public bool UsernameExists(string username)
    {
        return _db.Users.Any(u => u.Username == username);
    }

    public bool EmailExists(string email)
    {
        return _db.Users.Any(u => u.Email == email);
    }

    public User? Register(string username, string email, string password)
    {
        if (UsernameExists(username) || EmailExists(email))
            return null;

        var user = new User
        {
            Username = username,
            Email = email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
            CreatedAt = DateTime.UtcNow
        };

        _db.Users.Add(user);
        _db.SaveChanges();
        return user;
    }

    public User? Login(string username, string password)
    {
        var user = GetByUsername(username);
        if (user == null) return null;

        bool valid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        return valid ? user : null;
    }

    public void SaveProfile(int userId, UserProfile profile)
    {
        var existing = _db.UserProfiles.FirstOrDefault(p => p.UserId == userId);

        if (existing == null)
        {
            profile.UserId = userId;
            _db.UserProfiles.Add(profile);
        }
        else
        {
            existing.Age = profile.Age;
            existing.Gender = profile.Gender;
            existing.Weight = profile.Weight;
            existing.Height = profile.Height;
            existing.ActivityLevel = profile.ActivityLevel;
            existing.NoRestrictions = profile.NoRestrictions;
            existing.Vegetarian = profile.Vegetarian;
            existing.Vegan = profile.Vegan;
            existing.Pescatarian = profile.Pescatarian;
            existing.Keto = profile.Keto;
            existing.Paleo = profile.Paleo;
            existing.WeightLoss = profile.WeightLoss;
            existing.WeightGain = profile.WeightGain;
            existing.MaintainWeight = profile.MaintainWeight;
            existing.BuildMuscle = profile.BuildMuscle;
            existing.ImproveHealth = profile.ImproveHealth;
            existing.Allergies = profile.Allergies;
            existing.HealthRestrictions = profile.HealthRestrictions;
        }

        _db.SaveChanges();
    }
}