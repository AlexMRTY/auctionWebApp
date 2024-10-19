using System.Data;
using auctionWebApp.Areas.Identity.Data;
using auctionWebApp.core.Interface;
using auctionWebApp.persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace auctionWebApp.core;

public class UserService : IUserService
{
    private readonly UserManager<AppIdentityUser> _userManager;
    private readonly IUserPersistence _userPersistence;

    public UserService(UserManager<AppIdentityUser> userManager, IUserPersistence userPersistence)
    {
        _userManager = userManager;
        _userPersistence = userPersistence;
    }

    public async Task<List<AppIdentityUser>> GetAllUsersAsync()
    {
        return await _userManager.Users.ToListAsync();
    }

    public bool DeleteUser(string userName)
    {
        
    }
}