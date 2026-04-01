using Microsoft.AspNetCore.Mvc;
using MealCraft.Models;
using MealCraft.Services;

namespace MealCraft.Controllers;

public class AccountController : Controller
{
    private readonly UserService _userService;

    public AccountController(UserService userService)
    {
        _userService = userService;
    }

    // ───── LOGIN ─────

    [HttpGet]
    public IActionResult Login()
    {
        if (HttpContext.Session.GetInt32("UserId") != null)
            return RedirectToAction("Index", "Home");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(string username, string password)
    {
        var user = _userService.Login(username, password);

        if (user == null)
        {
            ModelState.AddModelError("", "Невалидно потребителско име или парола.");
            return View();
        }

        HttpContext.Session.SetInt32("UserId", user.Id);
        HttpContext.Session.SetString("Username", user.Username);

        return RedirectToAction("Index", "Home");
    }

    // ───── REGISTER ─────

    [HttpGet]
    public IActionResult Register()
    {
        if (HttpContext.Session.GetInt32("UserId") != null)
            return RedirectToAction("Index", "Home");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(string username, string email,
                                   string password, string confirmPassword)
    {
        if (string.IsNullOrWhiteSpace(username))
            ModelState.AddModelError("username", "Потребителското име е задължително.");

        if (string.IsNullOrWhiteSpace(email))
            ModelState.AddModelError("email", "Имейлът е задължителен.");

        if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            ModelState.AddModelError("password", "Паролата трябва да е поне 6 символа.");

        if (password != confirmPassword)
            ModelState.AddModelError("confirmPassword", "Паролите не съвпадат.");

        if (_userService.UsernameExists(username))
            ModelState.AddModelError("username", "Потребителското име вече е заето.");

        if (_userService.EmailExists(email))
            ModelState.AddModelError("email", "Имейлът вече е регистриран.");

        if (!ModelState.IsValid)
            return View();

        var user = _userService.Register(username, email, password);
        if (user == null)
        {
            ModelState.AddModelError("", "Регистрацията не успя. Опитайте отново.");
            return View();
        }

        HttpContext.Session.SetInt32("UserId", user.Id);
        HttpContext.Session.SetString("Username", user.Username);

        return RedirectToAction("Index", "Home");
    }

    // ───── LOGOUT ─────

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }

    // ───── PROFILE ─────

    [HttpGet]
    public IActionResult Profile()
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null)
            return RedirectToAction("Login");

        var user = _userService.GetById(userId.Value);
        var profile = user?.Profile;

        // Pre-fill form if profile already exists
        var vm = profile == null ? new ProfileViewModel() : new ProfileViewModel
        {
            Age = profile.Age,
            Gender = profile.Gender,
            Weight = profile.Weight,
            Height = profile.Height,
            ActivityLevel = profile.ActivityLevel,
            NoRestrictions = profile.NoRestrictions,
            Vegetarian = profile.Vegetarian,
            Vegan = profile.Vegan,
            Pescatarian = profile.Pescatarian,
            Keto = profile.Keto,
            Paleo = profile.Paleo,
            WeightLoss = profile.WeightLoss,
            WeightGain = profile.WeightGain,
            MaintainWeight = profile.MaintainWeight,
            BuildMuscle = profile.BuildMuscle,
            ImproveHealth = profile.ImproveHealth,
            Allergies = profile.Allergies,
            HealthRestrictions = profile.HealthRestrictions
        };

        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Profile(ProfileViewModel model)
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null)
            return RedirectToAction("Login");

        if (!ModelState.IsValid)
            return View(model);

        var profile = new UserProfile
        {
            Age = model.Age,
            Gender = model.Gender,
            Weight = model.Weight,
            Height = model.Height,
            ActivityLevel = model.ActivityLevel,
            NoRestrictions = model.NoRestrictions,
            Vegetarian = model.Vegetarian,
            Vegan = model.Vegan,
            Pescatarian = model.Pescatarian,
            Keto = model.Keto,
            Paleo = model.Paleo,
            WeightLoss = model.WeightLoss,
            WeightGain = model.WeightGain,
            MaintainWeight = model.MaintainWeight,
            BuildMuscle = model.BuildMuscle,
            ImproveHealth = model.ImproveHealth,
            Allergies = model.Allergies,
            HealthRestrictions = model.HealthRestrictions
        };

        _userService.SaveProfile(userId.Value, profile);
        return RedirectToAction("Index", "Home");
    }
}