using auctionWebApp.core;
using auctionWebApp.Models;
using auctionWebApp.persistence;
using AutoMapper;

namespace auctionWebApp.Mappers;

public class AuctionProfile : Profile
{
    public AuctionProfile()
    {
        CreateMap<AuctionItemDb, AuctionItem>().ReverseMap();
        CreateMap<AuctionItemDb, AuctionItemVm>().ReverseMap();
        CreateMap<AuctionItemVm, AuctionItem>().ReverseMap();
        
        CreateMap<AuctionItem, AuctionDetailsVm>().ReverseMap();
        CreateMap<BidDb, Bid>().ReverseMap();
        CreateMap<Bid, BidVm>().ReverseMap();
    }
}