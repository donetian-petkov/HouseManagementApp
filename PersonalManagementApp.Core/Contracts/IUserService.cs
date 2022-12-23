using Microsoft.AspNetCore.Identity;

namespace PersonalManagementApp.Core.Contracts;

public interface IUserService
{
    public IdentityUser Authenticate(string username, string password);

    public string GenerateJSONWebToken(IdentityUser user);

    public Task<bool> Logout(string username);

    public Task<bool> IsAdmin(string username);
}