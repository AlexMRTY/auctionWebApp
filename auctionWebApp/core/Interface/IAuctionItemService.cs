namespace auctionWebApp.core.Interface;

public interface IAuctionItemService
{
    List<AuctionItem> GetAllAuctionItems();
    IReadOnlyList<AuctionItem> GetAllAuctionItemsByUserName(string username);
    AuctionItem GetAuctionItemById (int id);
}