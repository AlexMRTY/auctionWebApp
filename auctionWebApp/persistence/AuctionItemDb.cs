using System.ComponentModel.DataAnnotations;
using auctionWebApp.core;

namespace auctionWebApp.persistence;

public class AuctionItemDb : BaseDB
{
    [Required]
    [MaxLength(120)]
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Starting price must be a non-negative value.")]
    public decimal StartingPrice { get; set; }
    
    public decimal ClosingPrice { get; set; }
    
    [Required]
    public DateTime StartTime { get; set; }
    
    [Required]
    public DateTime EndTime { get; set; }
    
    [Required]
    public string UserName { get; set; }
    
    [Required]
    public bool IsOpen { get; set; }

    // navigation property
    public List<BidDb> Bids { get; set; } = new List<BidDb>();


}