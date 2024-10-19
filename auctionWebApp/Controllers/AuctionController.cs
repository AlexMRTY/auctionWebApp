using System.Data;
using auctionWebApp.core;
using auctionWebApp.core.Interface;
using auctionWebApp.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace auctionWebApp.Controllers;
[Authorize]

public class AuctionController : Controller
{
    
    private IAuctionItemService _auctionItemService;
    private IMapper _mapper;
    
    public AuctionController(IAuctionItemService auctionItemService, IMapper mapper)
    {
        _auctionItemService = auctionItemService;
        _mapper = mapper;
    }

    public IActionResult Details(int id)
    {
        AuctionItem auctionItem = _auctionItemService.GetAuctionItemById(id);
        AuctionDetailsVm auctionDetailsVm = _mapper.Map<AuctionDetailsVm>(auctionItem);
        return View(auctionDetailsVm);
    }

    public IActionResult CreateAuctionItem()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult CreateAuctionItem(AuctionItemVm auctionItemVm)
    {
        
        
        if (
            auctionItemVm.Name.IsNullOrEmpty() ||
            auctionItemVm.Description.IsNullOrEmpty() ||
            auctionItemVm.StartingPrice <= 0
            )
        {
            return View(auctionItemVm);
        }
        auctionItemVm.StartTime = DateTime.Now;
        auctionItemVm.UserName = User.Identity.Name;
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


    public IActionResult EditDescription(int id, string userName)
    {
        
        AuctionItem auctionItem = _auctionItemService.GetAuctionItemById(id);
        return View(_mapper.Map<AuctionItemVm>(auctionItem));
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult EditDescription(AuctionItemVm auctionItemVm)
    {
        if (auctionItemVm.Description.IsNullOrEmpty())
        {
            return View(auctionItemVm);
        }
        
        try
        {
            _auctionItemService.UpdateDescription(auctionItemVm.Id, auctionItemVm.Description, auctionItemVm.UserName, User.Identity.Name);
        }
        catch ( DataException e)
        {
            return BadRequest();
        }

        return RedirectToAction("Index", "Home");
    }
}