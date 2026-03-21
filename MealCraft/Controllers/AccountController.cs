using Microsoft.AspNetCore.Mvc;

namespace MealCraft.Controllers;

public class AccountController : Controller
{
    public IActionResult Login()  => View();
    public IActionResult Register() => View();
    public IActionResult Profile() => View();

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || password?.Length < 6)
            return View();
        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public IActionResult Register(string username, string email,
        string password, string confirmPassword)
    {
        if (password != confirmPassword) return View();
        return RedirectToAction("Index", "Home");
    }

}