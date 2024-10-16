using auctionWebApp.core.Interface;
using auctionWebApp.Models;
using auctionWebApp.persistence;
using AutoMapper;

namespace auctionWebApp.core;

public class AuctionItemService : IAuctionItemService
{
    private readonly IAuctionItemPersistence _auctionItemPersistence;
    private readonly IMapper _mapper;
    
    public AuctionItemService (IAuctionItemPersistence auctionItemPersistence, IMapper mapper)
    {
        _auctionItemPersistence = auctionItemPersistence;
        _mapper = mapper;
    }
    public List<AuctionItem> GetAllAuctionItems()
    {
        List<AuctionItemDb> auctionItemDbs = _auctionItemPersistence.GetAll();
        List<AuctionItem> auctionItems = new List<AuctionItem>();
        foreach (var auctionItemDb in auctionItemDbs)
        {
            AuctionItem auctionItem = _mapper.Map<AuctionItem>(auctionItemDb);
            auctionItems.Add(auctionItem);
        }
        return auctionItems;
    }
    
    public IReadOnlyList<AuctionItem> GetAllAuctionItemsByUserName(string username)
    {
        throw new NotImplementedException();
    }
    
    public AuctionItem GetAuctionItemById (int id)
    {
        throw new NotImplementedException();
    }
    
    public void CreateAuctionItem (AuctionItemVm auctionItemVm)
    {
        _auctionItemPersistence.Add(_mapper.Map<AuctionItemDb>(auctionItemVm));
    }

    // private static readonly IReadOnlyList<AuctionItem> _auctionItems;
    // static AuctionItemService()
    // {
    //     _auctionItems = new List<AuctionItem>
    //     {
    //         new AuctionItem(1, "Item 1", "Description 1", 10.00m),
    //         new AuctionItem(2, "Item 2", "Description 2", 20.00m),
    //         new AuctionItem(3, "Item 3", "Description 3", 30.00m),
    //         new AuctionItem(4, "Item 4", "Description 4", 40.00m),
    //         new AuctionItem(5, "Item 5", "Description 5", 50.00m),
    //     };
    // }
}