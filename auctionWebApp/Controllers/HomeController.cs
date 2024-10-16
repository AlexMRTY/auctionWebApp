using System.Diagnostics;
using auctionWebApp.core;
using auctionWebApp.core.Interface;
using Microsoft.AspNetCore.Mvc;
using auctionWebApp.Models;
using AutoMapper;

namespace auctionWebApp.Controllers;

public class HomeController : Controller
{
    private IAuctionItemService _auctionItemService;
    private IMapper _mapper;

    public HomeController(IAuctionItemService auctionItemService, IMapper mapper)
    {
        _auctionItemService = auctionItemService;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        IReadOnlyList<AuctionItem> auctionItems = _auctionItemService.GetAllAuctionItems();
        List<AuctionItemVm> auctionItemVms = new List<AuctionItemVm>();
        foreach (var auctionItem in auctionItems)
        {
            auctionItemVms.Add(_mapper.Map<AuctionItemVm>(auctionItem));
        }
        return View(auctionItemVms);
    }
    
    

    // public IActionResult Privacy()
    // {
    //     return View();
    // }
    //
    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }
}