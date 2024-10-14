using auctionWebApp.core;

namespace auctionWebApp.Models;

public class AuctionItemVm
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal StartingPrice { get; set; }
    public List<Bid> Bids = new List<Bid>();
    
    public static AuctionItemVm FromAuctionItem(AuctionItem auctionItem)
    {
        return new AuctionItemVm()
        {
            Id = auctionItem.Id,
            Name = auctionItem.Name,
            Description = auctionItem.Description,
            StartingPrice = auctionItem.StartingPrice,
            Bids = auctionItem.Bids
        };
    }
}