using auctionWebApp.Areas.Identity.Data;
using auctionWebApp.core.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace auctionWebApp.core;

public class UserService : IUserService
{
    private readonly UserManager<AppIdentityUser> _userManager;

    public UserService(UserManager<AppIdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<List<AppIdentityUser>> GetAllUsersAsync()
    {
        return await _userManager.Users.ToListAsync();
    }
}