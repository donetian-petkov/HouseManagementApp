using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PersonalManagementApp.Core.Contracts;
using PersonalManagementApp.Core.Models.User;

namespace PersonalManagementApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public UserController(
            IUserService _userService, 
            UserManager<IdentityUser> _userManager,
            SignInManager<IdentityUser> _signInManager
        )
        {
            userService = _userService;
            userManager = _userManager;
            signInManager = _signInManager;
        } 

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserBindingModel loginUser)
        {
            var user = userService.Authenticate(loginUser.Username, loginUser.Password);

            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect." });
            }
            var tokenString = userService.GenerateJSONWebToken(user);

            var result = await signInManager.PasswordSignInAsync(user, loginUser.Password, true, false);

            if (result.Succeeded)
            {
                Console.WriteLine("Success!");
                return Ok(new { token = tokenString });

            }

            return Unauthorized();
        }


        [HttpPost("logout")]
        public async Task<bool> Logout([FromBody] LogoutUserBindingModel logoutModel)
        {
            return await userService.Logout(logoutModel.username);
        }
        
        [HttpPost("isAdmin")]
        public async Task<bool> IsAdmin([FromBody] IsAdminBindingModel isAdminModel)
        {
            return await userService.IsAdmin(isAdminModel.username);
        }
        
    }
}