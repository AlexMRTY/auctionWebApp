using System.ComponentModel.DataAnnotations;

namespace auctionWebApp.persistence;

public class BaseDB
{
    [Key]
    public int Id { get; set; }
}