using System.Data;
using auctionWebApp.core;
using auctionWebApp.core.Interface;
using auctionWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace auctionWebApp.Controllers;

public class AuctionController : Controller
{
    private IAuctionItemService _auctionItemService;
    
    public AuctionController(IAuctionItemService auctionItemService)
    {
        _auctionItemService = auctionItemService;
    }

    public IActionResult CreateAuctionItem()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult CreateAuctionItem(AuctionItemVm auctionItemVm)
    {
        if (!ModelState.IsValid)
        {
            return View(auctionItemVm);
        }

        try
        {
            _auctionItemService.CreateAuctionItem(auctionItemVm);
        }
        catch ( DataException e)
        {
            return BadRequest();
        }

        return RedirectToAction("Index", "Home");
    }
}