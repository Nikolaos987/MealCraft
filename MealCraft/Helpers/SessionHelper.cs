namespace MealCraft.Helpers;

public static class SessionHelper
{
    public static bool IsLoggedIn(IHttpContextAccessor accessor)
        => accessor.HttpContext?.Session.GetInt32("UserId") != null;

    public static int? GetUserId(IHttpContextAccessor accessor)
        => accessor.HttpContext?.Session.GetInt32("UserId");

    public static string? GetUsername(IHttpContextAccessor accessor)
        => accessor.HttpContext?.Session.GetString("Username");
}