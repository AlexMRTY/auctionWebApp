using auctionWebApp.core;
using auctionWebApp.core.Interface;
using auctionWebApp.persistence;
using auctionWebApp.persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// dependency injection of service into controller
builder.Services.AddScoped<IAuctionItemService, AuctionItemService>();

// dependency injection of persistence into service
builder.Services.AddScoped<IAuctionItemPersistence, AuctionItemPersistence>();

// dependency injection of generic persistence into persistence
builder.Services.AddScoped(typeof(IGenericPersistence<>), typeof(GenericPersistence<>));

// dependency injection of db context into generic persistence
builder.Services.AddDbContext<AuctionDbContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("AuctionDbConnection"));
});

// Auto mapper
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();