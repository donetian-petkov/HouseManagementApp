using PersonalManagementApp.Areas.Administration.Constants;
using PersonalManagementApp.Core.Models.Administration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PersonalManagementApp.Areas.Administration.Controllers
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
        [Authorize(Roles = "Administrator")]
        [Route("/admin/createRole")]
        public IActionResult CreateRole()
        {

            var model = new CreateRoleViewModel();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
        [Route("/admin/assignRole")]
        public async Task<IActionResult> AssignRole(AssignRoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByIdAsync(model.UserId);


            if (user == null || model.RoleName == null)
            {
                TempData[MessageConstant.ErrorMessage] = "Either the user or the role does not exist!";

                RedirectToAction("AssignRole", "Account", new { area = "Administration" });

            }
            
            var roles = await userManager.GetRolesAsync(user);

            if (roles.Any(x => x == model.RoleName))
            {
                TempData[MessageConstant.ErrorMessage] = "The user is already assigned to this role";

                RedirectToAction("AssignRole", "Account", new { area = "Administration" });

            }

            
            try
            {
                var result = await userManager.AddToRoleAsync(user, model.RoleName);

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
