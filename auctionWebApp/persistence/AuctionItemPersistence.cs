using auctionWebApp.core;
using auctionWebApp.core.Interface;

namespace auctionWebApp.persistence;

public class AuctionItemPersistence : GenericPersistence<AuctionItemDb>, IAuctionItemPersistence
{
    public AuctionItemPersistence(AuctionDbContext context) : base(context)
    {
    }
}