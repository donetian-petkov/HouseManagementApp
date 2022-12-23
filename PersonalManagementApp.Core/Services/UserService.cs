using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PersonalManagementApp.Core.Contracts;
using PersonalManagementApp.Infrastructure.Data;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace PersonalManagementApp.Core.Services;

public class UserService : IUserService
{
    
    private ApplicationDbContext context;
    private UserManager<IdentityUser> userManager;
    private readonly IConfiguration configuration;

    public UserService(ApplicationDbContext _context,
        UserManager<IdentityUser> _userManager,
        IConfiguration _configuration )
    {
        context = _context;
        userManager = _userManager;
        configuration = _configuration;
    }
    
    public IdentityUser Authenticate(string username, string password)
    {
        var user = userManager.FindByNameAsync(username).Result;
        
        if (user != null && userManager.CheckPasswordAsync(user, password).Result)
        {
            return user;
        }
        
        return null;
    }

    public string GenerateJSONWebToken(IdentityUser user)
    {
        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };
        
        string jwtSecret = configuration["JWT:Secret"];
        byte[] jwtSecretBytes = Encoding.UTF8.GetBytes(jwtSecret);
        var authSigningKey = new SymmetricSecurityKey(jwtSecretBytes);
        var token = new JwtSecurityToken(
            issuer: configuration["JWT:ValidIssuer"],
            audience: configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials:
            new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));
        return new JwtSecurityTokenHandler().WriteToken(token);
    }


    public async Task<bool> Logout(string username)
    {
        var user = userManager.FindByNameAsync(username);
            
        await userManager.UpdateSecurityStampAsync(await user);

        await userManager.RemoveAuthenticationTokenAsync(await user, "JWT", "JWT Token");

        return true;
    }
}