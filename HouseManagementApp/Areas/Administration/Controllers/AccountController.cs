using HouseManagementApp.Areas.Administration.Constants;
using HouseManagementApp.Core.Models.Administration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HouseManagementApp.Areas.Administration.Controllers
{
    [Authorize]
    [Area("Administration")]
    public class AccountController : Controller

    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public AccountController(
            RoleManager<IdentityRole> _roleManager,
            UserManager<IdentityUser> _userManager)
        {
            userManager = _userManager; 
            roleManager = _roleManager; 
        }


        [HttpGet]
        [Route("/admin/createRole")]
        public IActionResult CreateRole()
        {

            var model = new CreateRoleViewModel();

            return View(model);
        }

        [HttpPost]
        [Route("/admin/createRole")]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            var result = await roleManager.CreateAsync(new IdentityRole(model.RoleName));

            if (result.Succeeded)
            {
                TempData[MessageConstant.SuccessMessage] = "You created the role successfully!";

                return RedirectToAction("Index", "Home", new { area = "Administration" });

            }

            TempData[MessageConstant.ErrorMessage] = "Could not create role!";


            return View(model);

        }


    }
}
