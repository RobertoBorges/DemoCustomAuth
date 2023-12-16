using DemoCustomAuth.Pages;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace DemoCustomAuth.WebMVC.Controllers;

[Authorize]
public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [Authorize(AuthenticationSchemes = OpenIdConnectDefaults.AuthenticationScheme)]
    public IActionResult SignIn(string returnUrl)
    {
        _logger.LogInformation("User {@User} authenticated", User.Identity.Name);

        // "Catalog" because UrlHelper doesn't support nameof() for controllers
        // https://github.com/aspnet/Mvc/issues/5853
        return RedirectToAction("Index", "");
    }

    public async Task<IActionResult> Signout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);

        // "Catalog" because UrlHelper doesn't support nameof() for controllers
        // https://github.com/aspnet/Mvc/issues/5853
        // Build the home URL dynamically from the current request
        var request = HttpContext.Request;
        var homeUrl = $"{request.Scheme}://{request.Host}"; // This will give you the base URL
        return new SignOutResult(OpenIdConnectDefaults.AuthenticationScheme,
            new Microsoft.AspNetCore.Authentication.AuthenticationProperties { RedirectUri = homeUrl });
    }
}
