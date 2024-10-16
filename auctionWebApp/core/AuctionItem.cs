namespace auctionWebApp.core;


public class AuctionItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Description { get; set; }
    public bool IsOpen { get; set; }
    public decimal StartingPrice { get; set; }
    public decimal ClosingPrice { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public List<Bid> Bids = new List<Bid>();

    public AuctionItem(string name, string description, bool isOpen, decimal startingPrice, DateTime startTime, DateTime endTime, string userName)
    {
        Name = name;
        UserName = userName;
        Description = description;
        IsOpen = isOpen;
        StartingPrice = startingPrice;
        StartTime = startTime;
        EndTime = endTime;
    }
    
    public AuctionItem()
    {
    }

    public void AddBid(Bid bid)
    {
        Bids.Add(bid);
    }
    
}