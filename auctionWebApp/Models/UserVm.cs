using System.ComponentModel.DataAnnotations;

namespace auctionWebApp.Models;

public class UserVm
{
    [ScaffoldColumn(false)]
    public string Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
}