using System.ComponentModel.DataAnnotations;
using auctionWebApp.core;

namespace auctionWebApp.Models;

public class BidVm
{
    [ScaffoldColumn(false)]
    public int Id { get; set; }
    
    [ScaffoldColumn(false)]
    [Required]
    public int AuctionItemId { get; set; }
    
    [Required]
    [MaxLength(120)]
    public string UserName { get; set; }
    
    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal Amount { get; set; }
    
    [Required]
    public DateTime PlaceTime { get; set; }
    
    public static BidVm FromBid(Bid bid)
    {
        return new BidVm()
        {
            Id = bid.Id,
            AuctionItemId = bid.AuctionItemId,
            UserName = bid.UserName,
            Amount = bid.Amount,
            PlaceTime = bid.PlaceTime
        };
    }
}