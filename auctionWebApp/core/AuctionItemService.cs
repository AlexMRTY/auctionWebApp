using System.Data;
using auctionWebApp.core.Interface;
using auctionWebApp.Models;
using auctionWebApp.persistence;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;

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
        List<AuctionItem> auctionItems;
        try
        {
            List<AuctionItemDb> auctionItemDbs = _auctionItemPersistence.GetAll(
                a => a.EndTime > DateTime.Now, 
                q => q.OrderBy(a => a.EndTime)
            );
            auctionItems = new List<AuctionItem>();
            foreach (var auctionItemDb in auctionItemDbs)
            {
                AuctionItem auctionItem = _mapper.Map<AuctionItem>(auctionItemDb);
                auctionItems.Add(auctionItem);
            }
        } catch (DataException e)
        {
            throw new DataException("No items found");
        }
         
        return auctionItems;
    }
    
    public IReadOnlyList<AuctionItem> GetAllAuctionItemsByUserName(string userName)
    {
        List<AuctionItem> auctionItems;
        try
        {
            List<AuctionItemDb> auctionItemDbs = _auctionItemPersistence.GetAll(
                a => a.UserName == userName, 
                q => q.OrderBy(a => a.EndTime)
            );
            auctionItems = new List<AuctionItem>();
            foreach (var auctionItemDb in auctionItemDbs)
            {
                AuctionItem auctionItem = _mapper.Map<AuctionItem>(auctionItemDb);
                auctionItems.Add(auctionItem);
            }
        } catch (DataException e)
        {
            throw new DataException("No items found");
        }
         
        return auctionItems;
    }
    
    public AuctionItem GetAuctionItemById (int id)
    {
        return _mapper.Map<AuctionItem>(_auctionItemPersistence.GetById(
            id,
            a => a.Bids));
    }
    
    public void CreateAuctionItem (AuctionItemVm auctionItemVm)
    {
        if (
            auctionItemVm.Name.IsNullOrEmpty() ||
            auctionItemVm.Description.IsNullOrEmpty() ||
            auctionItemVm.StartingPrice <= 0
        ) throw new DataException();
        
        _auctionItemPersistence.Add(_mapper.Map<AuctionItemDb>(auctionItemVm));
    }
    
    public void UpdateDescription(int id, string description, string userName, string userIdentity)
    {
        if (description.IsNullOrEmpty()) throw new DataException();
        
        if (userName != userIdentity) throw new DataException("Unauthorized");
        
        AuctionItemDb item;
        try
        {
            item = _auctionItemPersistence.GetById(id);
        } catch (DataException e)
        {
            throw new DataException("Item not found");
        }
        
        item.Description = description;

        try
        {
            _auctionItemPersistence.Update(item);
        } catch (DataException e)
        {
            throw new DataException("Update failed");
        }
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