using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MealCraft.Controllers;

public class BaseController : Controller
{
    protected int? CurrentUserId =>
        HttpContext.Session.GetInt32("UserId");

    protected string? CurrentUsername =>
        HttpContext.Session.GetString("Username");

    protected bool IsLoggedIn => CurrentUserId != null;

    // Pass login state to every view automatically
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        ViewData["IsLoggedIn"] = IsLoggedIn;
        ViewData["CurrentUsername"] = CurrentUsername;
        base.OnActionExecuting(context);
    }
}