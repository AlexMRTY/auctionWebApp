using auctionWebApp.core;
using auctionWebApp.persistence;
using AutoMapper;

namespace auctionWebApp.Mappers;

public class AuctionItemProfile : Profile
{
    public AuctionItemProfile()
    {
        CreateMap<AuctionItemDb, AuctionItem>().ReverseMap();
    }
}