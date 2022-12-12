using HouseManagementApp.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace HouseManagementApp.Areas.Administration.Controllers;

[Area("Administration")]
[Authorize]
public class UserController : Controller
{
    private readonly UserManager<IdentityUser> userManager;

    private readonly SignInManager<IdentityUser> signInManager;

    public UserController(
        UserManager<IdentityUser> _userManager,
        SignInManager<IdentityUser> _signInManager)
    {
        userManager = _userManager;
        signInManager = _signInManager;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login()
    {
        if (User?.Identity?.IsAuthenticated ?? false)
        {
            return RedirectToAction("Index", "Home");
        }

        var model = new LoginViewModel();

        return View(model);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = await userManager.FindByNameAsync(model.UserName);

        if (user != null)
        {
            var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        ModelState.AddModelError("", "Invalid login");

        return View(model);
    }

    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();

        return RedirectToAction("Index", "Home");
    }
}