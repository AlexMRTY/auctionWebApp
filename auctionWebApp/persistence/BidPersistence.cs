using auctionWebApp.core.Interface;

namespace auctionWebApp.persistence;

public class BidPersistence : GenericPersistence<BidDb>, IBidPersistence 
{
    public BidPersistence(AuctionDbContext context) : base(context)
    {
        
    }
}