namespace auctionWebApp.core;

public class Bid
{
    public int Id { get; set; }
    public int AuctionItemId { get; set; }
    public string UserName { get; set; }
    public decimal Amount { get; set; }
    public DateTime PlaceTime { get; set; }

    public Bid(int id, string userName, decimal amount, DateTime placeTime)
    {
        Id = id;
        UserName = userName;
        Amount = amount;
        PlaceTime = placeTime;
    }

    public Bid()
    {
        
    }
}