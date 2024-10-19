using auctionWebApp.core;
using auctionWebApp.core.Interface;
using auctionWebApp.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace auctionWebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IUserService _userService;
        private IAuctionItemService _auctionItemService;
        private IMapper _mapper;

        public AdminController(IUserService userService, IAuctionItemService auctionItemService, IMapper mapper)
        {
            _userService = userService;
            _auctionItemService = auctionItemService;
            _mapper = mapper;
        }
        
        // GET: AdminController
        public IActionResult Index()
        {
            List<UserVm> users = new List<UserVm>();
            foreach (var user in _userService.GetAllUsersAsync().Result)
            {
                UserVm userVm = new UserVm();
                userVm.Id = user.Id;
                userVm.UserName = user.UserName;
                userVm.Email = user.Email;
                users.Add(userVm);
            }
            return View(users);
        }
        
        public IActionResult UserAuctions(string username)
        {
            IReadOnlyList<AuctionItem> auctionItems = _auctionItemService.GetAllAuctionItemsByUserName(username);
            List<AuctionItemVm> auctionItemVms = new List<AuctionItemVm>();
            foreach (var auctionItem in auctionItems)
            {
                auctionItemVms.Add(_mapper.Map<AuctionItemVm>(auctionItem));
            }
            return View(auctionItemVms);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAuction(int id)
        {
            bool result = _auctionItemService.DeleteAuctionItemById(id);
            if (result == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> DeleteUser(string username)
        {
            try
            {
                await _userService.DeleteUser(username);
                return View("Index");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Error: {ex.Message}" });
            }
        }
    }
}
