using auctionWebApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace auctionWebApp.core.Interface;

public interface IUserService
{
    Task<List<AppIdentityUser>> GetAllUsersAsync();
    void DeleteUser(string userName);
}