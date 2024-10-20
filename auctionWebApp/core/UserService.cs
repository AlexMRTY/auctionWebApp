using System.Data;
using auctionWebApp.Areas.Identity.Data;
using auctionWebApp.core.Interface;
using auctionWebApp.Data;
using auctionWebApp.persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace auctionWebApp.core;

public class UserService : IUserService
{
    private UserManager<AppIdentityUser> _userManager;
    
    private readonly IAuctionItemPersistence _auctionItemPersistence;

    public UserService(UserManager<AppIdentityUser> userManager, IAuctionItemPersistence auctionItemPersistence)
    {
        _userManager = userManager;
        _auctionItemPersistence = auctionItemPersistence;
    }

    public async Task<List<AppIdentityUser>> GetAllUsersAsync()
    {
        return await _userManager.Users.ToListAsync();
    }

    public async void DeleteUser(string userName)
    {
        // DELETE USER DATA
        // First Fetch the User you want to Delete
        try
        {
            _auctionItemPersistence.DeleteAll(_auctionItemPersistence.GetAll(x => x.UserName == userName));
        } catch (Exception e)
        {
            throw new DataException("Auctions Items not deleted");
        }   
        
        try
        {
            // DELETE USER
            //First Fetch the User you want to Delete
            AppIdentityUser user = _userManager.FindByEmailAsync(userName).Result;
            if (user == null)
            {
                // Handle the case where the user wasn't found
                throw new DataException("User not found");
            }

            //Delete the User Using DeleteAsync Method of UserManager Service
            _userManager.DeleteAsync(user);
            
        } catch (Exception e)
        {
            throw new DataException("User not deleted");
        }
        
    }
}