using auctionWebApp.core;
using auctionWebApp.Models;
using auctionWebApp.persistence;
using AutoMapper;

namespace auctionWebApp.Mappers;

public class AuctionItemProfile : Profile
{
    public AuctionItemProfile()
    {
        CreateMap<AuctionItemDb, AuctionItem>().ReverseMap();
        CreateMap<AuctionItemDb, AuctionItemVm>().ReverseMap();
        CreateMap<AuctionItemVm, AuctionItem>().ReverseMap();
    }
}