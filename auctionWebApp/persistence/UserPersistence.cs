using System.Data;
using System.Transactions;
using auctionWebApp.Areas.Identity.Data;
using auctionWebApp.core.Interface;
using auctionWebApp.Data;

namespace auctionWebApp.persistence;

public class UserPersistence : GenericPersistence<AppIdentityUser>, IUserPersistence
{
    public UserPersistence(AuctionDbContext context) : base(context)
    {
        
    }
}