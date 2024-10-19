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
        
        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
