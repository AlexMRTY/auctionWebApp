using System.Diagnostics;
using auctionWebApp.core;
using auctionWebApp.core.Interface;
using Microsoft.AspNetCore.Mvc;
using auctionWebApp.Models;

namespace auctionWebApp.Controllers;

public class HomeController : Controller
{
    private IAuctionItemService _auctionItemService;

    public HomeController(IAuctionItemService auctionItemService)
    {
        _auctionItemService = auctionItemService;
    }

    public IActionResult Index()
    {
        IReadOnlyList<AuctionItem> auctionItems = _auctionItemService.GetAllAuctionItems();
        List<AuctionItemVm> auctionItemVms = new List<AuctionItemVm>();
        foreach (var auctionItem in auctionItems)
        {
            auctionItemVms.Add(AuctionItemVm.FromAuctionItem(auctionItem));
        }
        return View(auctionItemVms);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}