using PersonalManagementApp.Areas.Administration.Constants;
using PersonalManagementApp.Core.Models.Administration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace PersonalManagementApp.Areas.Administration.Controllers;

[Area("Administration")]
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
    [Authorize(Roles = "Administrator")]
    [Route("/admin/createUser")]
    public IActionResult CreateUser()
    {

        var model = new RegisterViewModel();

        return View(model);
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    [Route("/admin/createUser")]
    public async Task<IActionResult> CreateUser(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = new IdentityUser()
        {
            Email = model.Email,
            UserName = model.UserName
        };

        var result = await userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            TempData[MessageConstant.SuccessMessage] = "The registration was successful!";

            await signInManager.PasswordSignInAsync(user, model.Password, false, false);

            return RedirectToAction("Index", "Home", new { area = "Administration" });

        }

        foreach (var item in result.Errors)
        {
            ModelState.AddModelError("", item.Description);
        }

        return View(model);
    }

    [HttpGet]
    [Route("/admin/login")]
    public IActionResult Login()
    {
        if (User?.Identity?.IsAuthenticated ?? false)
        {
            TempData[MessageConstant.ErrorMessage] = "You are already logged in!";

            return RedirectToAction("Index", "Home", new { area = "Administration" });
        }

        var model = new LoginViewModel();

        return View(model);
    }

    [HttpPost]
    [Route("/admin/login")]
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
                TempData[MessageConstant.SuccessMessage] = "Successful Login!";

                return RedirectToAction("Index", "Home", new { area = "Administration" });
            }
        }

        TempData[MessageConstant.ErrorMessage] = "Invalid Login!";


        return View(model);
    }

    [HttpPost]
    [Authorize]
    [Route("/admin/logout")]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();

        TempData[MessageConstant.SuccessMessage] = "You logged out successfully!";

        return RedirectToAction("Index", "Home", new { area = "Administration" });

    }
}