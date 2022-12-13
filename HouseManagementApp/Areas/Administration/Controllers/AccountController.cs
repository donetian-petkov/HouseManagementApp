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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await roleManager.CreateAsync(new IdentityRole(model.RoleName));

            if (result.Succeeded)
            {
                TempData[MessageConstant.SuccessMessage] = "You created the role successfully!";

                return RedirectToAction("Index", "Home", new { area = "Administration" });

            }

            TempData[MessageConstant.ErrorMessage] = "Could not create role!";


            return View(model);

        }


        [HttpGet]
        [Route("/admin/assignRole")]
        public IActionResult AssignRole()
        {

            var users = userManager.Users.ToList();

            var roles = roleManager.Roles.ToList();

            var model = new AssignRoleViewModel()
            {
                Users = users,
                Roles = roles
            };

            return View(model);
        }

        [HttpPost]
        [Route("/admin/assignRole")]
        public async Task<IActionResult> AssignRole(IdentityUser user, IdentityRole role)
        {


            if (user == null || role == null)
            {
                TempData[MessageConstant.ErrorMessage] = "Either the user or the role does not exist!";

                RedirectToAction("AssignRole", "Account", new { area = "Administration" });

            }


            try
            {
                var result = await userManager.AddToRoleAsync(user, role.ToString());

                if (result.Succeeded)
                {
                    TempData[MessageConstant.SuccessMessage] = "You assigned the role to the user successfully!";

                }

            } catch (Exception ex)
            {
                TempData[MessageConstant.ErrorMessage] = "Could not assign the role to the user! " + ex;

            }


            return RedirectToAction("Index", "Home", new { area = "Administration" });

        }

    }
}
