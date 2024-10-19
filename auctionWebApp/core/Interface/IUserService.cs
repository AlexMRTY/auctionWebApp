using auctionWebApp.Areas.Identity.Data;

namespace auctionWebApp.core.Interface;

public interface IUserService
{
    Task<List<AppIdentityUser>> GetAllUsersAsync();
    bool DeleteUser(string userName);
}