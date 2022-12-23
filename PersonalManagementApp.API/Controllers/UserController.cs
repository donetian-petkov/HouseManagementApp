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

        public UserController(
            IUserService _userService, 
            UserManager<IdentityUser> _userManager
        )
        {
            userService = _userService;
            userManager = _userManager;
        } 

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUserBindingModel loginUser)
        {
            var user = userService.Authenticate(loginUser.Username, loginUser.Password);

            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect." });
            }
            var tokenString = userService.GenerateJSONWebToken(user);
            
            return Ok(new { token = tokenString });
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