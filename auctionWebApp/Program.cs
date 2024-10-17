using auctionWebApp.core;
using auctionWebApp.core.Interface;
using auctionWebApp.persistence;
using auctionWebApp.persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;
using Microsoft.AspNetCore.Identity;
using auctionWebApp.Areas.Identity.Data;
using auctionWebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// dependency injection of service into controller
builder.Services.AddScoped<IAuctionItemService, AuctionItemService>();
builder.Services.AddScoped<IUserService, UserService>();

// dependency injection of persistence into service
builder.Services.AddScoped<IAuctionItemPersistence, AuctionItemPersistence>();

// dependency injection of generic persistence into persistence
builder.Services.AddScoped(typeof(IGenericPersistence<>), typeof(GenericPersistence<>));

// dependency injection of db context into generic persistence
builder.Services.AddDbContext<AuctionDbContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("AuctionDbConnection"));
});

builder.Services.AddDbContext<AppIdentityDbContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("IdentityDbConnection")));
builder.Services.AddDefaultIdentity<AppIdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>();


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

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=AuctionItem}/{action=CreateAuctionItem}");

using (var serviceScope = app.Services.CreateScope())
{
    var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new {Admin = "Admin"};
    
    if (!await roleManager.RoleExistsAsync(roles.Admin))
        await roleManager.CreateAsync(new IdentityRole(roles.Admin));
}

using (var serviceScope = app.Services.CreateScope())
{
    var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppIdentityUser>>();
    
    string email = "admin@gmail.com";
    string password = "Test1234,";

    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new AppIdentityUser();
        user.UserName = email;
        user.Email = email;
        user.EmailConfirmed = true;
        
        await userManager.CreateAsync(user, password);
        
        await userManager.AddToRoleAsync(user, "Admin");
    }
}

app.Run();