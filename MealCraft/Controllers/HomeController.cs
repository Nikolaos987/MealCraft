using Microsoft.AspNetCore.Mvc;

namespace MealCraft.Controllers;

public class HomeController : BaseController
{
    
    public IActionResult Index()
    {
        ViewData["ActivePage"] = "Home";
        return View();
    }

    public IActionResult About()
    {
        ViewData["ActivePage"] = "About";
        return View();
    }

    public IActionResult Contact()
    {
        ViewData["ActivePage"] = "Contact";
        return View();
    }
}