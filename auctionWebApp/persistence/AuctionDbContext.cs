using auctionWebApp.core;
using Microsoft.EntityFrameworkCore;

namespace auctionWebApp.persistence;

public class AuctionDbContext : DbContext
{
    public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options)
    {
    }

    public DbSet<AuctionItemDb> AuctionItem { get; set; }
    public DbSet<BidDb> Bid { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        AuctionItemDb aIDb = new AuctionItemDb
        {
            Id = -1,
            Name = "Bicycle",
            Description = "A red bicycle",
            StartTime = DateTime.Now,
            EndTime = DateTime.Now.AddDays(3),
            IsOpen = true,
            StartingPrice = 100,
            UserName = "alexmrty",
        };
        modelBuilder.Entity<AuctionItemDb>().HasData(aIDb);
        
        BidDb bdb1 = new BidDb()
        {
            Id = -1,
            Amount = 150,
            PlacedTime = DateTime.Now,
            UserName = "alexmrty",
            AuctionItemId = -1
        };
        BidDb bdb2 = new BidDb()
        {
            Id = -2,
            Amount = 200,
            PlacedTime = DateTime.Now,
            UserName = "anderslm",
            AuctionItemId = -1
        };
        modelBuilder.Entity<BidDb>().HasData(bdb1);
        modelBuilder.Entity<BidDb>().HasData(bdb2);
    }
}