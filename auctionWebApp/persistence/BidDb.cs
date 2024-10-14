using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace auctionWebApp.persistence;

public class BidDb : BaseDB
{
    [Required]
    public string UserName { get; set; }
    
    [Required]
    public decimal Amount { get; set; }
    
    [Required]
    public DateTime PlacedTime { get; set; }
    
    // FK
    [ForeignKey("AuctionItemId")]
    public AuctionItemDb AuctionItemDb { get; set; }
    
    public int AuctionItemId { get; set; }
}