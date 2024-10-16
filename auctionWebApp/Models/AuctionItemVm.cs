using System.ComponentModel.DataAnnotations;
using auctionWebApp.core;

namespace auctionWebApp.Models;

public class AuctionItemVm
{
    [ScaffoldColumn(false)]
    public int Id { get; set; }
    public string Name { get; set; }
    
    [Display(Name = "Published by")]
    public string UserName { get; set; }
    public string Description { get; set; }
    public decimal StartingPrice { get; set; }
    public decimal ClosingPrice { get; set; }
    
    [Display(Name = "Start Time")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
    public DateTime StartTime { get; set; }
    
    [Display(Name = "End Time")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
    public DateTime EndTime { get; set; }
    
    [Display(Name = "Open")]
    public bool IsOpen { get; set; }
    
    public static AuctionItemVm FromAuctionItem(AuctionItem auctionItem)
    {
        return new AuctionItemVm()
        {
            Id = auctionItem.Id,
            Name = auctionItem.Name,
            UserName = auctionItem.UserName,
            Description = auctionItem.Description,
            StartingPrice = auctionItem.StartingPrice,
            ClosingPrice = auctionItem.ClosingPrice,
            StartTime = auctionItem.StartTime,
            EndTime = auctionItem.EndTime,
            IsOpen = auctionItem.IsOpen
            
        };
    }
}